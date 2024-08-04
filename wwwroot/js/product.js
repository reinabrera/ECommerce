const productId = $('#Id.product-id').val();


/************************************** */
/** Media Library */

const mediaLibraryModal = $('#mediaLibraryModal');
const deleteModal = $('#deleteSelectedModal');

let imagesLoaded = false;
let mediaUpload = $('#mediaInput');
let delBtn = $('#deleteBtn');
let selectBtn = $('#selectImageBtn');


mediaLibraryModal.on('shown.bs.modal', async () => {
    if (imagesLoaded == false) {
        let images = await getProductImages();
        loadImages(images);
        imagesLoaded = true;
    }
});


mediaLibraryModal.on('hide.bs.modal', () => {
    // Reset Library Modal buttons and image border
    $('.image-checkbox:checkbox:checked').prop('checked', false);
    $('label.border').removeClass('border');
    delBtn.addClass("d-none");
    selectBtn.addClass("d-none");

    //Remove/reset event listener 
    selectBtn.off('click');
    $(document).off('change', '.product-images');
});


// Media select function for library modal
function selectMedia(e, multipleSelect) {
    e.target.nextElementSibling.classList.toggle("border");

    let selected = $('.image-checkbox:checkbox:checked');

    if (multipleSelect == true) {
        if (selected.length > 0) {
            delBtn.removeClass("d-none");
            selectBtn.removeClass("d-none");
        } else {
            delBtn.addClass("d-none");
            selectBtn.removeClass("d-none");
        }
    } else {
        if (selected.length == 1) {
            selectBtn.removeClass("d-none");
        } else {
            selectBtn.addClass("d-none");
        }

        if (selected.length > 0) {
            delBtn.removeClass("d-none");
        } else {
            delBtn.addClass("d-none");
        }
    }
}



$('#mediaUploadBtn').on('click', () => {
    mediaUpload.trigger('click');
})

mediaUpload.on('change', async (e) => {
    if (e.target.files.length > 0) {
        const uploaded = await uploadImages(e.target.files);
        if (uploaded != null) {
            loadImages(uploaded);
        }
    }
});

delBtn.on('click', () => {
    deleteModal.modal('show');
    $('.modal-backdrop').eq(1).addClass('delete-modal');
    $('.modal-custom-backdrop').toggleClass('active');
});

$('#deleteSelectedCancel, #deleteSelectedClose').on('click', () => {
    $('.modal-custom-backdrop').toggleClass('active');
})

$('#deleteSelectedConfirm').on('click', async () => {
    let selected = $('.image-checkbox:checkbox:checked');
    if (selected.length > 0) {
        const deleted = await deleteProductImages(selected);
        removeImages(deleted);
    }
});

$(document).on('click', '.remove-img-btn', function () {
    let selectedImg = $(this).siblings('.img-selected');
    $(this).remove();
    selectedImg.removeClass('img-selected');
    selectedImg.find('input, img').remove();
})
function loadImages(images) {
    const parentDiv = $('.product-images.row');
    for (let i = 0; i < images.length; i++) {
        let div =
            `<div class="col-md-3">
                    <div class="position-relative h-100 align-items-center d-flex">
                        <input type="checkbox" title="${images[i].FileName}" class="image-checkbox position-absolute opacity-0 w-100 h-100 top-0 start-0" data-id="${images[i].Id}" value="${images[i].FilePath}" id="p-img-${images[i].Id}">
                        <label class="form-check-label border-2 border-dark  d-flex align-items-center h-100" for="p-img-${images[i].Id}">
                            <img src="${images[i].FilePath}" class="img-fluid">
                        </label>
                    </div>
                </div>`

        parentDiv.append(div);
    }
}

function removeImages(imageIds) {

    let additionalImageDeleted = false;

    for (let i = 0; i < imageIds.length; i++) {
        const imgElement = $(`[data-id=${imageIds[i]}]`).closest('.col-md-3');
        const addtlImg = $(`[data-addtl-image-id=${imageIds[i]}]`);

        if (addtlImg != null) {
            addtlImg.remove();
            additionalImageDeleted = true;
        }

        imgElement.remove();
    }

    if (additionalImageDeleted) {
        const wrapper = $('.product-additional-images');

        wrapper.children().each(function (index) {
            $(this).attr('data-addtl-index', index);
            $(this).find('input').attr('name', `AdditionalImages[${index}].ImageId`);
        });
    }
}

async function uploadImages(uploads) {

    const formData = new FormData();

    formData.append('productId', productId)

    for (let i = 0; i < uploads.length; i++) {
        formData.append('images', uploads[i]);
    }

    try {
        const response = await fetch('/Admin/ProductImages/UploadProductImages', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status == "Success") {
            return JSON.parse(result.images);
        } else {
            throw new Error(result.status);
        }

    } catch (err) {
        console.error(err);
        throw err;
    }
}

async function deleteProductImages(images) {
    let formData = new FormData();

    formData.append("productId", productId);

    for (let i = 0; i < images.length; i++) {
        const imageId = images[i].getAttribute('data-id');
        formData.append("imageId", imageId);
    }

    try {
        const response = await fetch('/Admin/ProductImages/DeleteProductImages', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status == "Success") {
            $('label.border').removeClass('border');
            delBtn.addClass("d-none");
            selectBtn.addClass("d-none");
            $('.image-checkbox:checkbox:checked').prop('checked', false);
            deleteModal.modal('hide');
            $('.modal-custom-backdrop').toggleClass('active');

            return JSON.parse(result.deleted);
        } else {
            throw new Error(result.status);
        }

    } catch (err) {
        console.error(err);
        throw err;
    }

}
async function getProductImages() {

    let formData = new FormData();

    formData.append("productId", productId);

    try {
        const response = await fetch('/Admin/ProductImages/GetProductImages', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status == "Success") {
            return JSON.parse(result.images);
        } else {
            throw new Error(result.status);
        }

    } catch (err) {
        console.error(err);
        throw err;
    }
}


/************************************** */
/** Featured Image */

const featuredImgBtn = $('#featuredImgtBtn');

$(document).on('click', '#removeFeaturedImgBtn', () => {
    const featuredImgWrapper = $('.featured-img-wrapper');

    featuredImgWrapper.find('img, input, .remove-featured-img-btn').remove();
    featuredImgWrapper.addClass("no-featured-img");

    let defaultImg = `<img src="../../../dist/uploadImage.jpg" class="position-absolute default rounded w-100 h-100 top-0 start-0" />`
    featuredImgWrapper.append(defaultImg);
});

featuredImgBtn.on('click', selectFeaturedImage);
function selectFeaturedImage() {
    mediaLibraryModal.modal('show');

    let parentEl = featuredImgBtn.parent();

    $(document).on('change', '.product-images', function (e) {
        selectMedia(e, false);
    });

    selectBtn.on('click', () => {
        let selected = $('.image-checkbox:checkbox:checked');
        let selectedId;
        let imgSrc;
        if (selected.length == 1) {
            selectedId = selected.data('id');
            imgSrc = selected.val();

            parentEl.find('img, input, .remove-featured-img-btn').remove();
            parentEl.removeClass('no-featured-img');
            let input = `<input type="hidden" value="${selectedId}" name="FeaturedImageId" data-image-id="${selectedId}" />`;
            let img = `<img src="${imgSrc}" class="position-absolute featured-img w-100 h-100 top-0 start-0 rounded" />`
            let removeBtn =
            `<button type="button" class="btn btn-danger position-absolute remove-featured-img-btn p-0 rounded-circle" id="removeFeaturedImgBtn">
                <div class="d-flex justify-content-center align-items-center">
                    <i class="bi bi-x-lg"></i>
                </div>
            </button>`
            parentEl.append(input);
            parentEl.append(img);
            parentEl.append(removeBtn);
            mediaLibraryModal.modal('hide');
        }
    });
};

/***************************** */
/** Product Additional Images  */

$('#sortable').sortable();

const addtlImageBtn = $('#addAddtlImageBtn');

addtlImageBtn.on('click', selectAdditionalImages);

function selectAdditionalImages() {
    mediaLibraryModal.modal('show');
    const parentEl = $('.product-additional-images');
    let itemLength = parentEl.children().length;

    $(document).on('change', '.product-images', function (e) {
        selectMedia(e, true);
    });

    selectBtn.on('click', () => {
        let selected = $('.image-checkbox:checkbox:checked');
        let existingIds = [];
        parentEl.children().each(function () {
            existingIds.push($(this).data('addtl-image-id'));
        });

        if (selected.length > 0) {
            selected.each(function () {

                const imageId = $(this).data('id');
                if (!existingIds.includes(imageId)) {
                    const imgSrc = $(this).val();
                    const listEl =
                        `<li class="col-2 mb-2 position-relative" data-addtl-index=${itemLength} data-addtl-image-id="${imageId}">
                        <div class="position-relative">
                    <input type="hidden" value="${imageId}" name="AdditionalImages[${itemLength}].ImageId"/>
                    <img src="${imgSrc}" />
                    <button type="button" class="btn btn-danger position-absolute remove-addtl-img-btn p-0 rounded-circle">
                        <div class="d-flex justify-content-center align-items-center">
                            <i class="bi bi-x-lg"></i>
                        </div>
                    </button>
                    </div>
                </li>`
                parentEl.append(listEl);
                itemLength++;
                }
            })
        }

        mediaLibraryModal.modal('hide');
    })
}

$(document).on('click', '.remove-addtl-img-btn', function () {
    const wrapper = $('.product-additional-images');
    let deletedIndex = $(this).parent().parent().data('addtl-index');

    wrapper.children().each(function (index) {
        if (index > deletedIndex) {
            $(this).attr('data-addtl-index', index - 1);
            $(this).find('input').attr('name', `AdditionalImages[${index - 1}].ImageId`);
        }
    });

    $(this).parent().parent().remove();
});

$("#sortable").on("sortstop", function (event, ui)
{
    const wrapper = $('.product-additional-images');
    wrapper.children().each(function (index) {
        $(this).attr('data-addtl-index', index);
        $(this).find('input').attr('name', `AdditionalImages[${index}].ImageId`);
    });
});


/*********************************** */
/** Product Additional Details */

const addDetailBtn = $('#addDetailsBtn');

addDetailBtn.on('click', function () {
    let parentEl = $('.additional-details-wrapper');
    let length = parentEl.children().length;

    let divEl =
        `<div class="d-flex mb-2" data-detail-index="${length}">
            <div class="input-group">
                <input class="form-control ad-name" name="AdditionalDetails[${length}].Name" placeholder="Name" />
                <input class="form-control ad-value" name="AdditionalDetails[${length}].Value" placeholder="Value" /
            </div>
            <div class="ms-2">
                <button type="button" class="ms-1 btn btn-danger delete-detail-btn">
                    <i class="bi bi-trash"></i>
                </button>
            </div>
        </div>`

    parentEl.append(divEl);
});

$(document).on('click', '.delete-detail-btn', function () {
    const itemIndex = $(this).parent().parent().data('detail-index');
    let parentEl = $('.additional-details-wrapper');
    parentEl.children().each(function (index) {
        if (index > itemIndex) {
            $(this).attr('data-detail-index', index - 1);
            $(this).children('input').attr('name', `AdditionalDetails[${index - 1}].Id`);
            $(this).find('.ad-name').attr('name', `AdditionalDetails[${index - 1}].Name`);
            $(this).find('.ad-value').attr('name', `AdditionalDetails[${index - 1}].Value`);
        }
    });

    $(this).parent().parent().remove();
})

/** Categories */

let addCategory = $('#addCategory');
let categoriesItemsWrapper = $('.category-items');


categoriesItemsWrapper.on('click', function () {
    addCategory.focus();
})

addCategory.bind("keydown", function (e) {
    if (e.keyCode == 13 || e.keyCode == 188 || e.keyCode == 9) {
        e.preventDefault();

        const length = categoriesItemsWrapper.children().length;
        const value = $(this).val();

        let divEl =
            `<div class="category-item bg-primary ms-2 px-2 py-1 rounded text-light position-relative" data-category-index="${length - 1}">
            <input value="${value}" type="hidden" name="Categories[${length - 1}].Name" />
            <span>${value}</span>
            <button type="button" class="btn btn-danger position-absolute p-0 rounded-pill remove-category-btn">
                <i class="bi bi-x"></i>
            </button>
        </div>`

        $(divEl).insertBefore('.category-items > input');

        $(this).val("");
    }
});

$(document).on('click', '.remove-category-btn', function () {
    $(this).parent().remove();
    categoriesItemsWrapper.children().each(function (index) {
        $(this).attr('data-category-index', index);
        $(this).find('input[type=hidden]').attr("name", `Categories[${index}].Name`);
    });
})

/** Product Variation */

const attributeSelectEl = $('.select-attribute');
let attributeLoaded = false;
const addAttributeBtn = $('#addAttribute');
const termInput = $('.term-input');
const saveAttributeBtn = $('#saveAttributes');
attributeSelectEl.on('click', function () {

    if (attributeLoaded == false) {
        getAttributes();
    }
})

async function getAttributes() {
    try {
        const response = await fetch('/Admin/ProductAttributes/GetAttributes', {
            method: 'POST',
        });

        const result = await response.json();

        if (result.status == "Success") {
            appendAttributeToSelectEl(JSON.parse(result.attributes));
        }
    } catch (err) {
        console.error(err);
        throw err;
    }
}

function appendAttributeToSelectEl(items) {
    for (let i = 0; i < items.length; i++) {
        const attributeEl = $(`.accordion-item[data-attribute-id="${items[i].Id}"]`);

        const optionEl = $(`<option>`, { value: items[i].Id, text: items[i].Name });

        if (attributeEl.length == 1) {
            optionEl.addClass('text-muted');
            optionEl.attr('disabled', true);
        }

        attributeSelectEl.append(optionEl);
    }
    attributeLoaded = true;
}


attributeSelectEl.on('change', function () {
    attributeSelectEl.removeClass('text-muted');
})
addAttributeBtn.on('click', function () {
    const selected = attributeSelectEl.find('option:selected');
    const parentEl = $('#attributeAccordion');
    const index = parentEl.children().length + 1;

    if (selected.prop('disabled') != true) {
        parentEl.children().each(function () {
            $(this).find('.show').collapse('hide');
        });

        const attributeEl = createAttributeEl(selected.val(), selected.text(), index);

        selected.prop("disabled", true);
        parentEl.append(attributeEl);

        attributeSelectEl.find('option:eq(0)').prop('selected', true);
        selected.addClass('text-muted');
        selected.attr('disabled', true);
    }
});

function createAttributeEl(id, name, index) {
    const attributeEl = `
        <div class="accordion-item" data-attribute-id="${id}">
            <h2 class="accordion-header" id="headingOne">
                <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#attribute-index-${index}" aria-expanded="true" aria-controls="collapseOne">
                    <strong>${name}</strong>
                </button>
            </h2>
            <div id="attribute-index-${index}" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#attributeAccordion">
                <div class="accordion-body">
                    <div class="row">
                        <div class="col-3">
                            <div>
                                <span class="text-muted">Name:</span>
                            </div>
                            <div>
                                <span>Color</span>
                            </div>
                        </div>
                        <div class="col-9 position-relative">
                            <div>
                                <span class="text-muted">Value(s):</span>
                            </div>
                            <div class="d-flex terms-list border p-2">
                                <input type="text" class="border-0 term-input" data-attribute-id="${id}"/>
                            </div>
                            <ul class="dropdown-list position-absolute w-100 list-group" data-loaded="false">
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>`
    return attributeEl;
}

$(document).on("focus", '.term-input', async function () {
    const dropdownListEl = $(this).parent().siblings('.dropdown-list');
    const attributeId = $(this).data('attribute-id');

    if (dropdownListEl.attr('data-loaded') == "false") {
        const terms = await getAttributeTerms(attributeId);

        terms.forEach(function (item) {
            const termEl = `<li data-term-id="${item.Id}" class="list-group-item rounded-0">${item.Name}</li>`
            dropdownListEl.append(termEl);
        });

        dropdownListEl.attr('data-loaded', "true");
    }

    dropdownListEl.addClass('active');

    $(this).on("focusout", function () {
        setTimeout(function () {
            dropdownListEl.removeClass('active');
        }, 100)
        dropdownListEl.off('focusout');
    });
})

$(document).on('click', '.dropdown-list li', function () {
    let termListParentEl = $(this).closest('.accordion-body').find('.terms-list');


    if ($(this).attr('data-added') != "true") {
        const text = $(this).text();
        const termId = $(this).data('term-id');

        const termEl = createTermEl(termId, text);

        termListParentEl.find('.term-input').before(termEl);
    }
    
    $(this).attr('data-selected', "true");
});


function createTermEl(termId, text) {
    const termEl = `<div class="term-item bg-primary px-2 py-1 rounded text-light position-relative me-2" data-term-id=${termId}>
            <span>${text}</span>
            <button type="button" class="btn btn-danger position-absolute p-0 rounded-pill remove-term-btn">
                <i class="bi bi-x"></i>
            </button>
        </div>`

    return termEl;
}
async function getAttributeTerms(id) {

    if (id != null) {
        const formData = new FormData();

        formData.append('id', id);

        try {
            const response = await fetch('/Admin/ProductAttributes/GetAttributeTerms', {
                method: 'POST',
                body: formData
            });

            const result = await response.json();

            if (result.status == "Success") {
                return JSON.parse(result.terms);
            }
        } catch (err) {
            console.error(err);
            throw err;
        }
    }
}

$(document).on('click', '.remove-term-btn', function () {
    const termId = $(this).parent().data('term-id');
    const dropdownListItem = $(this).closest('.row').find(`[data-term-id=${termId}]`);
    dropdownListItem.attr('data-selected', "false");
    $(this).parent().remove();
});

saveAttributeBtn.on('click', async function () {
    const attributeParentEl = $('#attributeAccordion');


    let data = { "ProductId" : productId };

    data.Attributes = bindAttributesData(attributeParentEl.children());

    try {
        attributeParentEl.addClass('loading');
        attributeParentEl.append(loaderEl());
        const response = await fetch('/Admin/ProductAttributes/SaveProductAttributes', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

    } catch (err) {
        console.error(err);
        throw err;
    } finally {
        attributeParentEl.children().each(function () {
            $(this).find('.show').collapse('hide');
        });
        attributeParentEl.removeClass('loading');
        attributeParentEl.find('.spinner').remove();
    }

});

function bindAttributesData(data) {
    const attributes = [];
    data.each(function () {
        let attributeId = $(this).data('attribute-id');
        let terms = [];
        const termItemsEl = $(this).find('.terms-list');

        termItemsEl.children().each(function () {
            if ($(this).data('term-id') != null) {
                terms.push({ "Id" : $(this).data('term-id') });
            }
        });

        attributes.push({ "Id": attributeId, Terms: terms });
    });

    return attributes;
}


$(document).ready(async function () {
    // Product Attributes
    const attrAccordion = $('#attributeAccordion');
    const data = await getProductAttribute();

    for (let i = 0; i < data.Attributes.length; i++) {
        var attr = data.Attributes[i];

        const attrEl = createAttributeEl(attr.Id, attr.Name, i);

        attrAccordion.append(attrEl);
        attrAccordion.find('.show').collapse('hide');

        for (let j = 0; j < attr.Terms.length; j++) {
            var term = attr.Terms[j];
            const termEl = createTermEl(term.Id, term.Name);
            attrAccordion.children().last().find('.terms-list input').before(termEl);
        }
    }

    attrAccordion.removeClass('loading');
    attrAccordion.find('.spinner').remove();

    //Product Variations
    await getProductVariations();
})


async function getProductAttribute() {
    const attrAccordion = $('#attributeAccordion');
    const formData = new FormData();

    formData.append('productId', productId);

    try {

        attrAccordion.addClass('loading');
        attrAccordion.append(loaderEl());

        const response = await fetch('/Admin/ProductAttributes/GetProductAttributes', {
            method: 'POST',
            body: formData
        })

        const result = await response.json();

        if (result.status == "Success") {
            return JSON.parse(result.attributeTerms);
        }

    } catch (err) {
        attrAccordion.removeClass('loading');
        attrAccordion.find('.spinner').remove();
        console.error(err);
        throw err;
    }
}

function loaderEl() {
    const loader = `<div class="h-100 w-100 d-flex justify-content-center align-items-center spinner position-absolute top-0">
        <div class="spinner-border" role="status">
            <span class="sr-only"></span>
        </div>
    </div>`
    return loader;
}

const genVariationBtn = $('#generateVariation');

genVariationBtn.on('click', async function () {
    const variationAccordion = $('#variationAccordion');
    let variationData;
    const formData = new FormData();

    formData.append('productId', productId);

    try {
        variationAccordion.addClass('loading');
        variationAccordion.append(loaderEl());

        const response = await fetch('/Admin/ProductAttributes/GenerateProductVariation', {
            method: 'POST',
            body: formData,
        })

        const result = await response.json();

        if (result.status = "Success") {
            variationData = JSON.parse(result.variations);
        }
    } catch (err) {
        console.error(err);
        throw err;
    } finally {
        const length = variationAccordion.children().length - 1;
        if (variationData.length > 0) {
            variationData.forEach((item, index) => {
                const variationEl = createVariationEl(index + length, item.Id, item.Terms, item.ListPrice, item.SalePrice, item.Inventory, item.Image);

                variationAccordion.append(variationEl);
            });
        }

        variationAccordion.find('.spinner').remove();
        variationAccordion.removeClass('loading');
    }
});

$(document).on('click', '.select-variation-img', selectVariantImg)

function selectVariantImg() {
    const imgWrapper = $(this).parent();

    mediaLibraryModal.modal('show');
    $(document).on('change', '.product-images', function (e) {
        selectMedia(e, false);
    });

    selectBtn.on('click', () => {
        let selected = $('.image-checkbox:checkbox:checked');
        let selectedId;
        let imgSrc;
        if (selected.length == 1) {
            selectedId = selected.data('id');
            imgSrc = selected.val();
            imgWrapper.find('.selected-img').remove();
            imgWrapper.find('.default').addClass('d-none');

            const imgEl = `<img src="${imgSrc}" data-img-id=${selectedId} class="w-100 h-100 rounded border selected-img" />`
            const removeBtnEl = `<button type="button" class="btn btn-danger position-absolute remove-variant-img-btn p-0 rounded-circle">
                <div class="d-flex justify-content-center align-items-center">
                    <i class="bi bi-x-lg"></i>
                </div>
            </button>`

            imgWrapper.append(imgEl);
            imgWrapper.append(removeBtnEl);

            mediaLibraryModal.modal('hide');
        }
    });
}

async function getProductVariations() {

    const formData = new FormData();
    const variationAccordion = $('#variationAccordion');
    let variationData;

    formData.append('productId', productId);

    try {
        variationAccordion.addClass('loading');
        variationAccordion.append(loaderEl());

        const response = await fetch('/Admin/ProductAttributes/GetProductVariations', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status == "Success") {
            variationData = JSON.parse(result.variations);

        }

    } catch (err) {
        console.error(err);
        throw err;
    } finally {
        if (variationData.length > 0) {
            variationData.forEach((item, index) => {
                const variationEl = createVariationEl(index, item.Id, item.Terms, item.ListPrice, item.SalePrice, item.Inventory, item.Image);

                variationAccordion.append(variationEl);
            });
        }
        variationAccordion.find('.spinner').remove();
        variationAccordion.removeClass('loading');
    }
}

function createVariationEl(index, variationId, terms, listPrice, salePrice, inventory, image) {


    terms = terms.map((item) => {
        return item.Name;
    }).join(" | ");


    let imgEl;

    if (image != null) {
        imgEl = `<img src="${image.FilePath}" data-img-id=${image.Id} class="w-100 h-100 rounded border selected-img" />
        <button type="button" class="btn btn-danger position-absolute remove-variant-img-btn p-0 rounded-circle">
            <div class="d-flex justify-content-center align-items-center">
                <i class="bi bi-x-lg"></i>
            </div>
         </button>`
    }


    const variationEl = `<div class="accordion-item">
        <h2 class="accordion-header">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#variation-index-${index}" aria-expanded="false" aria-controls="variation-index-${index}">
                    ${terms}
            </button>
        </h2>
        <div id="variation-index-${index}" class="accordion-collapse collapse hide" data-variation-id="${variationId}" data-bs-parent="#variationAccordion">
            <div class="accordion-body">
                <div>
                    <div class="d-flex justify-content-between">
                        <div class="img--wrapper col-2 position-relative">
                            <button type="button" class="position-absolute w-100 h-100 top-0 start-0 select-variation-img opacity-0"></button>
                            <img src="../../../dist/uploadImage.jpg" class="w-100 h-100 rounded border default ${image != null ? 'd-none' : ''}"/>
                            ${image != null ? imgEl : ""}
                        </div>
                        <div>
                            <button type="button" class="btn btn-outline-danger delete-variation" data-variation-id="${variationId}">Delete Variation</button>
                        </div>
                    </div>

                    <hr />
                    <div class="input-group">
                        <input type="number" class="form-control list-price" placeholder="Listing Price" ${listPrice != null && "value=" + listPrice} />
                        <input type="number" class="form-control sale-price" placeholder="Sale Price" ${salePrice != null && "value=" + salePrice} />
                        <input type="number" class="form-control inventory" placeholder="Inventory" ${inventory != null && "value=" + inventory} />
                    </div>
                </div>
            </div>
        </div>
    </div>`
    return variationEl;
}

$(document).on('click', '.remove-variant-img-btn', function () {
    $(this).siblings('.selected-img').remove();
    $(this).siblings('.default').removeClass('d-none');
    $(this).remove();
});

const saveVariationBtn = $('#saveVariations');

saveVariationBtn.on('click', async function () {
    const variationAccordion = $('#variationAccordion');

    let data = { "ProductId": productId };

    data.Variants = BindProductVariations(variationAccordion.children());

    let updatedVariation;

    try {
        variationAccordion.append(loaderEl);
        variationAccordion.addClass('loading');
        const response = await fetch('/Admin/ProductAttributes/UpdateProductVariations', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const result = await response.json();

        if (result.status == "Success") {
            updatedVariation = JSON.parse(result.update);
        }

    } catch (err) {
        console.error(err);
        throw err;
    } finally {
        variationAccordion.find('> div').not('.spinner').remove();
        if (updatedVariation.length > 0) {
            updatedVariation.forEach((item, index) => {
                const variationEl = createVariationEl(index, item.Id, item.Terms, item.ListPrice, item.SalePrice, item.Inventory, item.Image);

                variationAccordion.append(variationEl);
            });
        }
        variationAccordion.find('.spinner').remove();
        variationAccordion.removeClass('loading');
    }

})


function BindProductVariations(elements) {
    variation = [];
    elements.each(function () {
        content = $(this).find('> div');
        id = content.data('variation-id');
        listPrice = content.find('.input-group .list-price').val() || null;
        salePrice = content.find('.input-group .sale-price').val() || null;
        inventory = content.find('.input-group .inventory').val() || null;
        imgId = content.find('.img--wrapper .selected-img').data('img-id') || null;
        const data = { "Id": id, "ListPrice": listPrice, "SalePrice": salePrice, "Inventory": inventory, "ImageId": imgId };
        variation.push(data);
    })
    return variation;
}


$(document).on('click', '.delete-variation', async function () {
    const variationAccordion = $('#variationAccordion');
    const variantId = $(this).data('variation-id');

    const formData = new FormData();

    formData.append('productId', productId);
    formData.append('variantId', variantId);


    try {
        variationAccordion.append(loaderEl);
        variationAccordion.addClass('loading');

        const response = await fetch('/Admin/ProductAttributes/DeleteProductVariation', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status == "Success") {
            const deletedVariantId = JSON.parse(result.deleted);
            if (deletedVariantId == variantId) {
                $(this).closest('.accordion-item').remove();
            }
        }


    } catch (err) {
        console.error(err);
        throw err;

    } finally {
        variationAccordion.find('.spinner').remove();
        variationAccordion.removeClass('loading');
    }
});


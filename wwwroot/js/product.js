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
        const response = await fetch('/ProductImages/UploadProductImages', {
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
        const response = await fetch('/ProductImages/DeleteProductImages', {
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
        const response = await fetch('/ProductImages/GetProductImages', {
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

    let defaultImg = `<img src="../../dist/uploadImage.jpg" class="position-absolute default rounded w-100 h-100 top-0 start-0" />`
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
//addCategory.on('focus', function () {
//    $(this).on("keypress")
//});

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
    console.log("Hello");
    categoriesItemsWrapper.children().each(function (index) {
        $(this).attr('data-category-index', index);
        $(this).find('input[type=hidden]').attr("name", `Categories[${index}].Name`);
    });
})

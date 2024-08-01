﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*********************************************** */
/** Global */

const footer = $('footer');

const body = $('body');
body.css('margin-bottom', footer.height());

/****************************************** */
/** Partnership Pages */

const uploadLogoBtn = $('#uploadLogoBtn');
const uploadLogoInput = $('#uploadLogoInput');

uploadLogoBtn.on('click', function () {
    uploadLogoInput.click();
})

uploadLogoInput.on('change', function (e) {
    const file = e.target.files[0];
    const parentEl = $('.company-logo--wrapper');
    if (file) {
        uploadLogoInput.removeAttr('hidden', false);
        parentEl.find('.selected-img').remove();
        const imgSrc = window.URL.createObjectURL(file);
        let imgEl = `<img src=${imgSrc} class="position-absolute selected-img rounded w-100 h-100 top-0 start-0 opacity-100" />`
        parentEl.append(imgEl);
        parentEl.find('.default').addClass('d-none');
    }
});

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

/*************************************************** */
/** Homepage */

/** Logo Carousel */

let splideEl = $('.splide');

if (splideEl.length > 0) {
    console.log('hello');
    var splide = new Splide('.splide', {
        type: 'loop',
        perPage: 6,
        perMove: 1,
        autoplay: true,
        interval: 1500,
        gap: '50px',
        pagination: false,
    });

    splide.mount();
}


/********************************************** */
/** Global Site Media Library */

const globalMediaLibrary = $('#globalMediaLibraryModal');
const globalAddImgBtn = $('#globalAddImgBtn');
const globalMediaUploadBtn = $('#globalMediaUploadBtn');
let globalMediaInput = $('#globalMediaInput');
const globalSelectBtn = $('#globalSelectImageBtn');
const globalDelBtn = $('#globalDeleteBtn');
const globalDelModal = $('#globalDeleteSelectedModal');

let globalImagesLoaded = false;
globalAddImgBtn.on('click', function () {
    globalMediaLibrary.modal('show');
})

globalMediaLibrary.on('shown.bs.modal', async function () {
    if (globalImagesLoaded == false) {
        const result = await getImages();
        if (result.length > 0) {
            loadImages(result);
        }
        globalImagesLoaded = true;
    }
})

globalMediaLibrary.on('hide.bs.modal', function () {
    $(document).off('change', '.global-images');
    $('.global-images input:checked').prop('checked', false);
    $('.global-images label').each(function () {
        $(this).removeClass('border');
    });
    globalSelectBtn.addClass('d-none');
})
globalMediaUploadBtn.on('click', function () {
    globalMediaInput.click();
})

globalMediaInput.on('change', async function (e) {
    if (e.target.files.length > 0) {
        const uploaded = await uploadImages(e.target.files)
        if (uploaded.length > 0) {
            loadImages(uploaded);
        }
    }
})

async function getImages() {
    try {
        const response = await fetch('/SiteMedia/GetImages', {
            method: 'POST',
        });

        const result = await response.json();

        if (result.status == "Success") {
            return JSON.parse(result.images);
        }

    } catch (err) {
        console.error(err);
        throw err;
    }
}
async function uploadImages(files) {
    console.log('test');
    let formData = new FormData();

    for (let i = 0; i < files.length; i++) {
        formData.append('file', files[i]);
    }

    try {
        const response = await fetch('/SiteMedia/UploadImages', {
            method: 'POST',
            body: formData,
        });

        const result = await response.json();

        if (result.status == "Success") {
            return JSON.parse(result.images);
        }
    } catch (err) {
        console.error(err);
        throw err;
    }
}

function loadImages(images) {
    const parentDiv = $('.global-images.row');
    for (let i = 0; i < images.length; i++) {
        let div =
            `<div class="col-md-3">
                    <div class="position-relative h-100 align-items-center d-flex">
                        <input type="checkbox" title="${images[i].FileName}" class="image-checkbox position-absolute opacity-0 w-100 h-100 top-0 start-0" data-id="${images[i].Id}" value="${images[i].FilePath}" id="g-img-${images[i].Id}">
                        <label class="form-check-label border-2 border-dark  d-flex align-items-center h-100" for="p-img-${images[i].Id}">
                            <img src="${images[i].FilePath}" class="img-fluid">
                        </label>
                    </div>
                </div>`
        parentDiv.append(div);
    }
}

function globalSelectMedia(e, multipleSelect) {
    e.target.nextElementSibling.classList.toggle("border");

    let selected = $('.image-checkbox:checkbox:checked');

    if (multipleSelect == true) {
        if (selected.length > 0) {
            globalDelBtn.removeClass("d-none");
            globalSelectBtn.removeClass("d-none");
        } else {
            globalDelBtn.addClass("d-none");
            globalSelectBtn.removeClass("d-none");
        }
    } else {
        if (selected.length == 1) {
            globalSelectBtn.removeClass("d-none");
        } else {
            globalSelectBtn.addClass("d-none");
        }

        if (selected.length > 0) {
            globalDelBtn.removeClass("d-none");
        } else {
            globalDelBtn.addClass("d-none");
        }
    }
}

globalDelBtn.on('click', function () {
    globalDelModal.modal('show');
    $('.modal-backdrop').eq(1).addClass('delete-modal');
    $('.modal-custom-backdrop').toggleClass('active');
});

$('#globalDeleteSelectedCancel, #globalDeleteSelectedClose').on('click', () => {
    $('.modal-custom-backdrop').toggleClass('active');
})

$('#globalDeleteSelectedConfirm').on('click', async () => {
    let selected = $('.image-checkbox:checkbox:checked');
    if (selected.length > 0) {
        const deleted = await deleteImages(selected);
        removeImages(deleted);
    }
});

async function deleteImages(selected) {

    let formData = new FormData();

    for (let i = 0; i < selected.length; i++) {
        const fileId = selected[i].getAttribute('data-id');
        formData.append('fileId', fileId);
    }
    try {
        const response = await fetch('/SiteMedia/DeleteImages', {
            method: 'POST',
            body: formData,
        });

        const result = await response.json();

        if (result.status == "Success") {
            $('label.border').removeClass('border');
            globalDelBtn.addClass("d-none");
            globalSelectBtn.addClass("d-none");
            $('.image-checkbox:checkbox:checked').prop('checked', false);
            globalDelModal.modal('hide');
            $('.modal-custom-backdrop').toggleClass('active');

            return JSON.parse(result.deleted);
        }
    } catch (err) {
        console.error(err);
        throw err;
    }
}

function removeImages(imageIds) {

    for (let i = 0; i < imageIds.length; i++) {
        const imgElement = $(`[data-id=${imageIds[i]}]`).closest('.col-md-3');
        const selectedImg = $(`[data-img-id=${imageIds[i]}]`);
        selectedImg.remove();
        imgElement.remove();
    }
}

/************************************************** */
/** Attribute Page */

function createTermInput(count, type) {
    let inputEl;
    if (type == "Button") {
        inputEl = `<div class="input--wrapper mt-2">
            <input type="text" class="form-control" name="Terms[${count}].Name" required >
            <span class="text-danger field-validation-valid" data-valmsg-for="Terms[${count}].Name" data-valmsg-replace="true"></span>
        </div>`
    } else if (type == "Color") {
        inputEl = `<div class="input--wrapper mt-2 row gx-2">
            <div class="col-9">
                <input type="text" class="form-control" name="Terms[${count}].Name" required>
            </div>
            <div class="col-3">
                <input type="color" class="form-control h-100 color-picker" name="Terms[${count}].ColorValue" required>
            </div>
            <span class="text-danger field-validation-valid" data-valmsg-for="Terms[${count}].ColorValue" data-valmsg-replace="true"></span>
        </div>`
    }
    return inputEl;
}

$('.attribute-radios input[type="radio"]').on('change', async function () {
    let parentEl = $(this).closest('.card');
    let attrWrapperEl = parentEl.find('.attributes-radios--wrapper');
    let radioGrpLen = attrWrapperEl.children().length;
    let checked = attrWrapperEl.find('input[type="radio"]:checked');

    if (checked.length == radioGrpLen) {
        const termIds = [];
        checked.each(function () {
            termIds.push($(this).val())
        })

        const data = await GetProductImageByVariant(parentEl.data('product-id'),termIds);

        if (data != null || data != undefined) {
            parentEl.find('.img--wrapper img').attr('src', data);
        }
    }
    
})

async function GetProductImageByVariant(productId, termIds) {

    const formData = new FormData();

    for (let i = 0; i < termIds.length; i++) {
        formData.append('productId', productId);
        formData.append('termId', termIds[i]);
    }

    try {

        const response = await fetch('/Customer/Products/GetProductImageByVariant', {
            method: 'POST',
            body: formData
        });

        const result = await response.json();

        if (result.status = "Success") {
            console.log(result);
            return JSON.parse(result.data);
        }

    } catch (err) {
        console.error(err);
        throw err;
    }
}


$(document).ready(function () {
    const dualRangeSlider = $('.dual-range-slider--wrapper');

    if (dualRangeSlider.length > 0) {
        slideOne();
        slideTwo();
    }
});

let sliderOne = document.getElementById("slider-1");
let sliderTwo = document.getElementById("slider-2");
let displayValOne = document.getElementById("sliderMin");
let displayValTwo = document.getElementById("sliderMax");
let minGap = 1;
let sliderTrack = document.querySelector(".slider-track");
let sliderMinValue = document.getElementById("slider-1").min;
let sliderMaxValue = document.getElementById("slider-1").max;

function slideOne() {
    if (parseInt(sliderTwo.value) - parseInt(sliderOne.value) <= minGap) {
        sliderOne.value = parseInt(sliderTwo.value) - minGap;
    }
    displayValOne.textContent = "$" + sliderOne.value + " – ";
    fillColor();
}
function slideTwo() {
    if (parseInt(sliderTwo.value) - parseInt(sliderOne.value) <= minGap) {
        sliderTwo.value = parseInt(sliderOne.value) + minGap;
    }
    displayValTwo.textContent = "$" + sliderTwo.value;
    fillColor();
}
function fillColor() {
    percentMin = ((sliderOne.value - sliderMinValue ) / (sliderMaxValue - sliderMinValue)) * 100;
    percentMax = ((sliderTwo.value - sliderMinValue) / (sliderMaxValue - sliderMinValue)) * 100;

    if (isNaN(percentMin)) {
        $('.dual-range-slider--wrapper').addClass('slider-disabled');
    }
    sliderTrack.style.background = `linear-gradient(to right, #ebebf1 ${percentMin}% , #000000 ${percentMin}% , #000000 ${percentMax}%, #ebebf1 ${percentMax}%)`;
}
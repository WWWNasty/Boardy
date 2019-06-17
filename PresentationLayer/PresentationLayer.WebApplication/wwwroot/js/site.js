$(document).ready(() => {
    let uploadImageContainer = $(".upload-images-container");

    let base64Containers = $(".base64-image-container");

    let uploadedImagesBase64 = base64Containers.filter((index, container) => $(container).val());

    let maxUploadersCount = +uploadImageContainer.attr("max-image-count");

    let imageUploader = new ImageUploader(maxUploadersCount);

    if (uploadedImagesBase64.length == 0) {
        imageUploader.addUploader(uploadImageContainer, $(base64Containers.first()));
    }

    $("#add-image-button").click(event => imageUploader.addUploader(uploadImageContainer));
    $("#remove-image-button").click(event => imageUploader.removeUploader(uploadImageContainer));


    uploadedImagesBase64.each(
        (index, base64Container) => imageUploader.addUploader(uploadImageContainer, $(base64Container)));

    $('[data-toggle="tooltip"]').tooltip();
});

class ImageUploader {
    maxUploadersCount = 5;

    allowedTypes = ["image/png", "image/jpeg"];

    uploaders = [];

    constructor(maxUploadersCount) {
        this.maxUploadersCount = maxUploadersCount;
    }

    addUploader (container, base64Container = null) {
        if (base64Container == null) {
            base64Container = $($(".base64-image-container").get(this.uploaders.length));
        }

        if (this.uploaders.length < this.maxUploadersCount) {
            var templateClone = $("#image-form-template").clone();

            templateClone.attr("id", "image-upload-" + this.uploaders.length);


            let label = $(templateClone).find(".advert-photo-label");

            label.css('backgroundImage', `url(${base64Container.val()})`);

            templateClone.find(".advert-photo").change(event => {
                let uploadedFile = event.target.files[0];

                if(uploadedFile && !this.allowedTypes.includes(uploadedFile.type)){
                    alert("Тип файла не поддерживается поддерживаемые файлы " + this.allowedTypes);
                    return;
                }

                if (uploadedFile) {
                    var fileReader = new FileReader();

                    fileReader.onload = () => {
                        label.css("backgroundImage", `url(${fileReader.result})`);

                        base64Container.val(fileReader.result);
                    }

                    fileReader.readAsDataURL(uploadedFile);
                    this.addUploader(container);
                }
            });

            container.append(templateClone);
            this.uploaders.push({ element: templateClone, dataContainer: base64Container });
        }
    }

    removeUploader(container) {
            let removingElement = this.uploaders.pop();

            removingElement.element.remove();
            removingElement.dataContainer.val('');
        

            if(this.uploaders.length == 0){
                this.addUploader(container);
            }
    }

}
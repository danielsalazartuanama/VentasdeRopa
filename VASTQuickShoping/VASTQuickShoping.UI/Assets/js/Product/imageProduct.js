const miFile1 = document.getElementById('miFile1');
const miFile2 = document.getElementById('miFile2');
const miFile3 = document.getElementById('miFile3');
const miFile4 = document.getElementById('miFile4');

miFile1.addEventListener('change', function () {
    let archivo = miFile1.files[0];
    if (archivo) {
        let reader = new FileReader();
        reader.readAsDataURL(archivo);
        reader.onloadend = function () {
            document.getElementById('imgProduct1').src = reader.result;
        };
    }
});

miFile2.addEventListener('change', function () {
    let archivo = miFile2.files[0];
    if (archivo) {
        let reader = new FileReader();
        reader.readAsDataURL(archivo);
        reader.onloadend = function () {
            document.getElementById('imgProduct2').src = reader.result;
        };
    }
});

miFile3.addEventListener('change', function () {
    let archivo = miFile3.files[0];
    if (archivo) {
        let reader = new FileReader();
        reader.readAsDataURL(archivo);
        reader.onloadend = function () {
            document.getElementById('imgProduct3').src = reader.result;
        };
    }
});

miFile4.addEventListener('change', function () {
    let archivo = miFile4.files[0];
    if (archivo) {
        let reader = new FileReader();
        reader.readAsDataURL(archivo);
        reader.onloadend = function () {
            document.getElementById('imgProduct4').src = reader.result;
        };
    }
});

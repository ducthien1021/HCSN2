/**
 * Xử lý dữ liệu số
 * @param {Number} value giá trị cần xử lý
 * Author: vtahoang - (23/06/2023)
 */
function numberHandler(value) {
    try {
        if (value != null) {
            value = value.toString();
            // xoá các ký tự không phải số
            value = value.replace(/[^0-9]/g, "");
            // xoá số 0 đầu tiên
            if (value.length > 1) value = value.replace(/^0+/, "");
            //thêm dấu . sau mỗi 3 số
            var parts = value.split(".");
            parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ".");
            return parts.join(".");
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

/**
 * Không nhận event từ thẻ cha
 * Author: vtahoang (06/07/2023)
 */
function stopPropagation() {
    try {
        event.stopPropagation();
    } catch (error) {
        console.log("stopPropagation ~ error:", error);
    }
}

/**
 * Tạo chuỗi ngẫu nhiên
 * @param {*} length chiều dài chuỗi
 * @returns chuỗi ngẫu nhiên
 * Author: vtahoang (06/07/2023)
 */
function makeid(length) {
    let result = "";
    const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    const charactersLength = characters.length;
    let counter = 0;
    while (counter < length) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
        counter += 1;
    }
    return result;
}

/**
 * Xử lý dữ liệu ngày tháng năm
 * @param {string || date} value
 * @returns {date || string} ngày tháng năm
 * Author: vtahoang (13/07/2023)
 */
function dateHandler(value) {
    try {
        // if (date != null) {
        //     date = new Date(date);
        //     let month = (date.getMonth() + 1).toString().padStart(2, "0");
        //     return `${date.getDate().toString().padStart(2, "0")}/${month}/${date.getFullYear()}`;
        // }
        // return "";
        if (value == null) {
            value = "";
        }
        if (typeof value == "string") {
            // xoá các ký tự không phải số
            value = value.replace(/[^0-9]/g, "");
            // xoá - và /
            let result = "";
            let day = "";
            let month = "";
            let year = "";
            //0-1 là ngày 2-3 là tháng 4-7 là năm
            for (let i = 0; i < 8; i++) {
                if (i < 2) {
                    if (value[i]) day += value[i];
                    else day += "-";
                }
                if (i > 1 && i < 4) {
                    if (value[i]) month += value[i];
                    else month += "-";
                }
                if (i > 3) {
                    if (value[i]) year += value[i];
                    else year += "-";
                }
            }
            // ngày lớn hơn 31 thì gán = 31
            // tháng lớn hơn 12 thì gán = 12
            if (parseInt(day) > 31) day = "31";
            if (parseInt(month) > 12) month = "12";
            if (parseInt(year) > 2023) year = "2023";
            result = `${day}/${month}/${year}`;
            return result;
        }
        if (typeof value == "object") {
            value = new Date(value);
            let month = (value.getMonth() + 1).toString().padStart(2, "0");
            return `${value.getDate().toString().padStart(2, "0")}/${month}/${value.getFullYear()}`;
        }
    } catch (error) {
        console.log(error);
        return "";
    }
}

export default { numberHandler, dateHandler, stopPropagation, makeid, dateHandler };

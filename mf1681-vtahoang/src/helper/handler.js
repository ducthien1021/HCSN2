/**
 * Xử lý dữ liệu số
 * @param {Number} value giá trị cần xử lý
 * Author: vtahoang - (23/06/2023)
 */
function numberHandler(value) {
    try {
        if (value != null) {
            var parts = value.toString().split(".");
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
 * Date handler
 * @param {Date} date ngày tháng
 * Author: vtahoang (04/07/2023)
 */
function dateHandler(date) {
    try {
        if (date != null) {
            date = new Date(date);
            let month = date.getMonth() + 1;
            return `${date.getDate()}/${month}/${date.getFullYear()}`;
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

export default { numberHandler, dateHandler };

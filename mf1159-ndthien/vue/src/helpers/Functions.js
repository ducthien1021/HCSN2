const MISAFunctions = {
    /**
     * Hàm thực hiện convert số thành tiền (Ex: 100000 -> 100.000)
     * Author: NDThien 12/7/2023
     */
    convertNumberToCurrency(number) {
        try {
            let currencyString = 0;
            // Thực hiện parse
            number = parseInt(number, 10);
            if (!isNaN(number)) {
                currencyString = number.toLocaleString("vi-VN");
            }
            return currencyString;
        } catch (error) {
            console.log(error);
        }
    },
    /**
     * Hàm thực hiện convert Tiền thành số (Ex: 100.000 -> 100000)
     * Author: NDThien 12/7/2023
     */
    convertCurrencyToNumber(currencyString) {
        try {
            return currencyString.toString().split(".").join("");
        } catch (error) {
            console.log(error);
        }
    },
    /**
     * Hàm thực hiện format date dd/mm/yyyy
     * Author: NDThien 12/7/2023
     * @param {*} timestamp: Thời gian cần format
     * @returns 
     */
    formatDate(timestamp) {
        const date = new Date(timestamp);
        let day = date.getDate();
        day = day < 10 ? `0${day}` : day;
        let month = date.getMonth() + 1;
        month = month < 10 ? `0${month}` : month;
        let year = date.getFullYear();
        return `${day}/${month}/${year}`;
    },
    /**
     * Hàm convert string date format type: dd/MM/yyy -> Date object
     * @param {*} dateString 
     * @returns DateObject
     */
    convertToDate(dateString) {
        //  Convert a "dd/MM/yyyy" string into a Date object
        let d = dateString.split("/");
        let dat = new Date(d[2] + '/' + d[1] + '/' + d[0]);
        return dat;
    }
}


export default MISAFunctions
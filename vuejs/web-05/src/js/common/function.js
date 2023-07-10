const MisaFunction = {
  formatdouble: function (string) {
    return string.replaceAll(".", ",");
  },

  formatMoney: function (money) {
    if (!isNaN(money)) {
      var moneyInt = parseInt(money)
        .toString()
        .replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");
      return moneyInt;
    } else {
      return parseInt(money);
    }
  },
  convertMoneyToNum: function (s) {
    try {
      if (s != "") return parseInt(s.replaceAll(".", ""));
      return 0;
    } catch (Ex) {
      return 0;
    }
  },
  // formatDate(date) {
  //   try {
  //     if (date) {
  //       date = new Date(date);
  //       let newDate = date.getDate();
  //       let month = date.getMonth() + 1;
  //       let year = date.getFullYear();
  //       newDate = newDate < 10 ? `0${newDate}` : newDate;
  //       month = month < 10 ? `0${month}` : month;
  //       return `${newDate}/${month}/${year}`;
  //     }
  //   } catch (error) {
  //     return "";
  //   }
  // },
  inputEnterNumber(evt) {
    var charCode = evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      evt.preventDefault();
    } else {
      return true;
    }
  },
  formatActive(active) {
    switch (active) {
      case 0:
        active = "Chưa sử dụng";
        break;
      case 1:
        active = "Đã sử dụng";
        break;

      default:
        active = "";
    }
    return active;
  },
};
export default MisaFunction;

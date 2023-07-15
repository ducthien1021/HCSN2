<template>
    <div class="h-datepicker">
        <label>{{ label }} <span v-if="required">*</span></label>

        <div v-if="errormsg" class="h-datepicker__errormsg">{{ errormsg }}</div>
        <div class="h-datepicker__popup">
            <DatePicker ref="datePicker" v-model:value="inputValue">
                <template #icon-calendar> </template>
                <template #input>
                    <div class="h-datepicker__input">
                        <input
                            :textRight="textRight"
                            type="text"
                            :placeholder="placeholder"
                            :disabled="disable"
                            v-model="inputValue"
                            ref="input"
                            :tabindex="tabindex"
                            @keydown="keyDownEvent"
                        />
                        <div v-if="icon" class="h-datepicker__icon">
                            <MISAIcon :icon="icon"></MISAIcon>
                        </div>
                    </div>
                </template>
            </DatePicker>
        </div>
    </div>
</template>

<style scoped>
@import url("./MISADatePicker.css");
</style>

<style>
.mx-calendar {
    width: 262px;
}
.mx-input {
    border: none;
    box-shadow: none;
}
</style>

<script>
import DatePicker from "vue-datepicker-next";
import MISAIcon from "../MISAIcon/MISAIcon.vue";
import "vue-datepicker-next/index.css";

/**
 * kiểm tra đã hợp lệ chưa
 * Author: vtahoang (04/07/2023)
 */
function isValid() {
    try {
        let value = this.inputValue;
        // error message khi validate dữ liệu
        this.errormsg = this.validator(value);
        // cập nhật lại error message
        this.$emit("update:modeErrormsg", this.errormsg);
        if (!this.errormsg) {
            // không có lỗi thì cập nhật lại giá trị và xoá class error
            this.$emit("update:modelValue", value);
            this.$refs.input.classList.remove("h-datepicker--error");
            return true;
        } else {
            // có lỗi thì thêm class error
            this.$refs.input.classList.add("h-datepicker--error");
            return false;
        }
    } catch (error) {
        console.log(error);
        return false;
    }
}

/**
 * Validate dữ liệu
 * @param {String} value
 * Author: vtahoang (04/07/2023)
 */

function validator(value) {
    try {
        if (this.required && (value === "" || value == null || value == undefined)) {
            return "Trường này không được để trống";
        }
        if (this.inputValue.replace(/[^0-9]/g, "").length < 8) {
            return "Trường này không hợp lệ";
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

/**
 * Xoá dữ liệu
 * Author: vtahoang (13/07/2023)
 */
function keyDownEvent() {
    try {
        if (event.keyCode == this.$_MISAEnum.keyCode.delete) {
            // loại bỏ ký tự không phải số và xoá số cuối
            this.inputValue = this.inputValue.replace(/[^0-9]/g, "");
            this.inputValue = this.inputValue.substring(0, this.inputValue.length - 1);
        }
    } catch (error) {
        console.log("keyDownEvent ~ error:", error);
    }
}

/**
 * Ẩn bảng chọn ngày tháng
 * Author: vtahoang (14/07/2023)
 */
function hideDatePicker() {
    try {
        // // ẩn bảng chọn ngày tháng sau 100ms
        // setTimeout(() => {
        //     this.showDatePicker = false;
        // }, 100);
    } catch (error) {
        console.log("hideDatePicker ~ error:", error);
    }
}

export default {
    name: "MISADatePicker",
    components: {
        DatePicker,
        MISAIcon,
    },
    data() {
        return {
            inputValue: this.dateHandler(this.modelValue),
            errormsg: this.modeErrormsg,
        };
    },
    props: {
        label: {
            type: String,
            default: "",
        },
        placeholder: {
            type: String,
            default: "",
        },
        required: {
            type: Boolean,
            default: false,
        },
        value: {
            type: String,
            default: "",
        },
        disable: {
            type: Boolean,
            default: false,
        },
        textRight: {
            type: Boolean,
            default: false,
        },
        icon: {
            type: String,
            default: "",
        },
        modelValue: {},
        modeErrormsg: {
            type: String,
            default: "",
        },
        tabindex: {
            type: Number,
            default: 0,
        },
    },
    watch: {
        modelValue: function (value) {
            this.inputValue = this.dateHandler(value);
        },
        inputValue: function (value) {
            this.inputValue = this.dateHandler(value);
            this.showDatePicker = false;
            // if (this.isValid()) {
            //     this.$emit("update:modelValue", this.dateHandler(value));
            // }
        },
    },
    methods: {
        isValid,
        validator,
        keyDownEvent,
        hideDatePicker,
    },
};
</script>

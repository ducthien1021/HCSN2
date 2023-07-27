<template>
    <div class="h-textfield">
        <label>{{ label }} <span v-if="required">*</span></label>
        <div v-if="icon" class="h-textfield__icon">
            <MISAIcon :icon="icon"></MISAIcon>
            <div
                v-if="icon == 'up_down_arrows'"
                class="h-icon__arrow h-icon__arrow-up"
                @click="inputValue++"
            ></div>
            <div
                v-if="icon == 'up_down_arrows'"
                class="h-icon__arrow h-icon__arrow-down"
                @click="inputValue--"
            ></div>
        </div>
        <input
            :textRight="textRight"
            type="text"
            :placeholder="placeholder"
            :disabled="disable"
            v-model="inputValue"
            ref="input"
            :tabindex="tabindex"
            @keydown="changeValueWithKey"
        />
        <div v-if="errormsg" class="h-textfield__errormsg">{{ errormsg }}</div>
    </div>
</template>

<style scoped>
@import url(./MISATextfield.css);
</style>

<script>
import MISAIcon from "../MISAIcon/MISAIcon.vue";

/**
 * focus vào input
 * Author: vtahoang (04/07/2023)
 */
function focus() {
    try {
        this.$refs.input.focus();
    } catch (error) {
        console.log(error);
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
        if (this.number) {
            if (value <= 0) return "Trường này phải lớn hơn 0";
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

/**
 * kiểm tra đã hợp lệ chưa
 * Author: vtahoang (04/07/2023)
 */
function isValid() {
    try {
        let value = this.inputValue;
        if (this.number) value = this.inputValue.replaceAll(".", "");
        // error message khi validate dữ liệu
        this.errormsg = this.validator(value);
        // cập nhật lại error message
        this.$emit("update:modeErrormsg", this.errormsg);
        if (!this.errormsg) {
            // không có lỗi thì cập nhật lại giá trị và xoá class error
            this.$emit("update:modelValue", value);
            this.$refs.input.classList.remove("h-textfield--error");
            return true;
        } else {
            // có lỗi thì thêm class error
            this.$refs.input.classList.add("h-textfield--error");
            return false;
        }
    } catch (error) {
        console.log(error);
        return false;
    }
}

/**
 * Tăng giảm giá trị với button
 * Author: vtahoang (12/07/2023)
 */
function changeValueWithKey() {
    try {
        if (this.number) {
            let value = this.inputValue.replaceAll(".", "");
            if (event.keyCode == 38) value = parseInt(value) + 1;
            if (event.keyCode == 40) value = parseInt(value) - 1;
            this.inputValue = this.numberHandler(value);
        }
    } catch (error) {
        console.log("changeValueWithKey ~ error:", error);
    }
}

export default {
    name: "MISATextfield",
    components: {
        MISAIcon,
    },
    data() {
        var inputValue;
        if (this.number) {
            inputValue = this.numberHandler(this.modelValue);
        } else {
            inputValue = this.modelValue;
        }
        return {
            inputValue,
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
        number: {
            type: Boolean,
            default: false,
        },
        tabindex: {
            type: Number,
            default: 0,
        },
    },
    computed: {},
    methods: {
        focus,
        validator,
        isValid,
        changeValueWithKey,
    },
    watch: {
        inputValue() {
            if (this.number) {
                this.inputValue = this.numberHandler(this.inputValue);
            }
            if (this.isValid()) {
                this.$emit("update:modelValue", this.inputValue);
            }
        },
        modelValue(value) {
            this.inputValue = value;
        },
    },
};
</script>

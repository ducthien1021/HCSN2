<template>
    <div class="h-textfield">
        <label>{{ label }} <span v-if="required">*</span></label>
        <div v-if="icon" class="h-textfield__icon">
            <MISAIcon :icon="icon"></MISAIcon>
        </div>
        <input
            :textRight="textRight"
            type="text"
            :placeholder="placeholder"
            :disabled="disable"
            v-model="inputValue"
            ref="input"
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
 * @param {String} value giá trị của input
 * Author: vtahoang (04/07/2023)
 */
function validator(value) {
    try {
        if (this.required && value == "") {
            return this.$_MISAResources.errormsg.empty;
        }
        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

export default {
    name: "MISATextfield",
    components: {
        MISAIcon,
    },
    data() {
        return {
            inputValue: this.modelValue,
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
    },
    computed: {},
    methods: {
        focus,
        validator,
    },
    watch: {
        inputValue(value) {
            // error message khi validate dữ liệu
            this.errormsg = this.validator(value);
            if (!this.errormsg) {
                // không có lỗi thì cập nhật lại giá trị và xoá class error
                this.$emit("update:modelValue", value);
                this.$refs.input.classList.remove("h-textfield--error");
            } else {
                // có lỗi thì thêm class error
                this.$refs.input.classList.add("h-textfield--error");
            }
            // cập nhật lại error message
            this.$emit("update:modeErrormsg", this.errormsg);
        },
        modelValue(value) {
            this.inputValue = value;
        },
    },
};
</script>

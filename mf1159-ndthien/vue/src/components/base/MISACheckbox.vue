<template>
    <div>
        <label for="mycheckbox">{{ label }}</label>
        <input
            id="mycheckbox"
            type="checkbox"
            :value="value"
            :checked="isChecked"
            v-model="model"
            :disabled="isDisabled"
        />
    </div>
</template>
<script>
export default {
    name: "MISACheckbox",
    emits: ["update:modelValue"],
    props: {
        label: {
            // Label của checkbox
            type: String,
            required: false,
            default: "",
        },
        isChecked: {
            // trạng thái checked của checbox
            type: Boolean,
            required: false,
            default: false,
        },
        isDisabled: {
            // trạng thái checked của checbox
            type: Boolean,
            required: false,
            default: false,
        },
        value: {
            // Value của checkbox
            type: [String, Number],
            required: false,
            default: null,
        },
        modelValue: {
            // Custom 2 way binding bằng Boolean hoặc Array2
            type: [Boolean, Array],
            required: true,
        },
    },
    data() {
        return {};
    },
    computed: {
        /**
         * Tính toán cập nhật giá trị cho checkbox
         * Author: NDThien 3/7/2023
         */
        model: {
            get() {
                return this.modelValue;
            },
            set(value) {
                this.$emit("update:modelValue", value);
            },
        },
    },
};
</script>
<style>
@import url(../../css/base/checkbox.css);
</style>

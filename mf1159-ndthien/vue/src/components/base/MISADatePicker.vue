<template>
    <el-date-picker
        type="date"
        :value-format="valueFormat"
        :format="format"
        :placeholder="placeholder"
        :tabindex="tabindex"
        :class="[isError ? 'is-error' : '']"
    />
</template>
<script>
export default {
    name: "MISADatePicker.vue",
    props: {
        tabindex: {
            type: Number,
            required: false,
            default: -1,
        },
        placeholder: {
            type: String,
            required: false,
            default: "dd/MM/yyyy",
        },
        valueFormat: {
            type: String,
            required: false,
            default: "DD/MM/YYYY",
        },
        format: {
            type: String,
            required: false,
            default: "DD/MM/YYYY",
        },
        isError: {
            type: Boolean,
            required: false,
            default: false,
        },
    },
    data() {
        return {};
    },
    methods: {},
};
</script>
<style scoped>
@import url(../../css/base/datepicker.css);
</style>

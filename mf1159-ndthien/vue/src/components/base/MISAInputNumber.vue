<template>
    <el-input-number
        controls-position="right"
        :precision="precision"
        :step="step"
        :max="max"
        :min="min"
        :class="[isError ? 'is-error' : '']"
    />
</template>
<script>
export default {
    name: "MISAInputNumber",
    props: {
        tabindex: {
            type: Number,
            required: false,
            default: -1,
        },
        precision: {
            type: Number,
            required: false,
            default: 0,
        },
        min: {
            type: Number,
            required: false,
            default: Infinity,
        },
        max: {
            type: Number,
            required: false,
            default: Infinity,
        },
        step: {
            type: Number,
            required: false,
            default: 0.1,
        },
        isError: {
            type: Boolean,
            required: false,
            default: false,
        },
    },
    mounted() {
        // Custom tabindex được truyền từ prop
        this.$el.querySelector(".el-input__inner").tabIndex = this.tabindex;
    },
    methods: {},
};
</script>
<style scoped>
@import url(../../css/base/input-number.css);
</style>

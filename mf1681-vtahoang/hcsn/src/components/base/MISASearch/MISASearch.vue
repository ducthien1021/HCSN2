<template>
    <label class="h-search" for="toolbar-search">
        <div class="h-search__icon"></div>
        <input
            id="toolbar-search"
            type="text"
            class="h-search__input"
            :placeholder="placeholder"
            v-model="inputValue"
            :tabindex="tabindex"
        />
    </label>
</template>

<style scoped>
@import url(./MISASearch.css);
</style>

<script>
export default {
    data() {
        return {
            inputValue: this.modelValue,
        };
    },
    props: {
        // placeholder truyền vào
        placeholder: {
            type: String,
            default: "",
        },
        modelValue: {
            type: String,
            default: "",
        },
        tabindex: {
            type: Number,
            default: -1,
        },
    },
    watch: {
        modelValue(value) {
            this.inputValue = value;
        },
        inputValue(value) {
            this.$emit("update:modelValue", value);
        },
    },
};
</script>

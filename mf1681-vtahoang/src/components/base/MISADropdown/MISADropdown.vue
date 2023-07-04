<template>
    <div class="h-dropdown">
        <div class="h-dropdown__icon"></div>
        <div class="h-dropdown__current">{{ text }}</div>
        <div class="h-dropdown__expand"></div>
    </div>
</template>

<style scoped>
@import url(./MISADropdown.css);
</style>

<script>
export default {
    props: {
        text: {
            type: String,
            default: "",
        },
        dataList: {
            type: Array,
            default: () => [],
        },
    },
};
</script>

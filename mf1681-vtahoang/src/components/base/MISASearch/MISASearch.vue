<template>
    <label class="h-search" for="toolbar-search">
        <div class="h-search__icon"></div>
        <input id="toolbar-search" type="text" class="h-search__input" :placeholder="placeholder" />
    </label>
</template>

<style scoped>
@import url(./MISASearch.css);
</style>

<script>
export default {
    props: {
        // placeholder truyền vào
        placeholder: {
            type: String,
            default: "",
        },
    },
};
</script>

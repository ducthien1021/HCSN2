<template>
    <div class="h-table">
        <div :class="mainClasses" class="h-table__main"></div>
        <div :class="footerClasses" class="h-table__footer"></div>
    </div>
</template>

<style scoped>
@import url(./MISATable.css);
</style>

<script>
export default {
    props: {
        mainClasses: {
            type: Array,
            default: () => [],
        },
        footerClasses: {
            type: Array,
            default: () => [],
        },
    },
};
</script>

<template>
    <div refs="container" class="h-icon" :class="icon" :style="style"></div>
</template>

<script>
export default {
    name: "MISAIcon",
    props: {
        // icon truyền vào
        icon: {
            type: String,
            default: "",
        },
        // style
        style: {
            type: Object,
            default: () => ({}),
        },
    },
};
</script>

<style scoped>
@import url(./MISAIcon.css);
</style>

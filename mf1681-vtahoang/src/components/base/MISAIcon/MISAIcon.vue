<template>
    <div refs="container" class="h-icon" :class="icon"></div>
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
    },
};
</script>

<style>
@import url(./MISAIcon.css);
</style>

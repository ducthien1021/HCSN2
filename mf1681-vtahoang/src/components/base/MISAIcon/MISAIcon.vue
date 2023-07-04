<template>
    <div refs="container" class="h-icon" :class="icon"></div>
</template>

<script>
const props = {
    icon: {
        type: String,
        default: "",
    },
};

export default {
    name: "MISAIcon",
    props,
};
</script>

<style>
@import url(./MISAIcon.css);
</style>

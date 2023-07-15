<template>
    <div class="h-contextmenu" :style="style">
        <div class="h-contextmenu__item" @click="addAsset">Thêm tài sản</div>
        <div class="h-contextmenu__item" @click="editAsset">Sửa tài sản</div>
        <div class="h-contextmenu__item" @click="deleteAsset">Xoá tài sản</div>
        <div class="h-contextmenu__item" @click="duplicateAsset">Nhân bản</div>
    </div>
</template>

<style scoped>
@import url(./MISAContextMenu.css);
</style>

<script>
export default {
    name: "MISAContextMenu",
    props: {
        x: Number,
        y: Number,
    },
    data() {
        return {
            style: {
                left: this.x + "px",
                top: this.y + "px",
            },
        };
    },
    watch: {
        x() {
            this.style.left = this.x + "px";
        },
        y() {
            this.style.top = this.y + "px";
        },
    },
    methods: {
        addAsset() {
            this.$emit("addAsset");
        },
        editAsset() {
            this.$emit("editAsset");
        },
        deleteAsset() {
            this.$emit("deleteAsset");
        },
        duplicateAsset() {
            this.$emit("duplicateAsset");
        },
    },
};
</script>

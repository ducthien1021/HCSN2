<template>
    <div class="search">
        <div class="search__icon">
            <MISAIcon :pX="this.$_icons.search.pX" :pY="this.$_icons.search.pY" :width="this.$_icons.search.width"
                :height="this.$_icons.search.height" :boxHeight="this.$_icons.search.boxHeight"
                :boxWidth="this.$_icons.search.boxWidth" :scale="this.$_icons.search.scale" />
        </div>
        <div class="search__input">
            <input type="text" placeholder="Tìm kiếm tài sản" />
        </div>
    </div>
</template>

<script>
import MISAIcon from "../icon/MISAIcon.vue";

export default {
    name: 'MISASearchInput',
    components: {
        MISAIcon,
    },
}
</script>

<style scoped>
.search {
    display: flex;
    align-items: center;
    width: 180px;
    height: 36px;
    border-radius: 3px;
    background-color: #ffffff;
    border: 1px solid #ebeef5;
    padding: 6px;
    box-sizing: border-box;
    position: relative;
}

.search:hover,
.search:focus-within {
    border: 1px solid #007bff;
}

.search__icon {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 24px;
    height: 24px;
}

.search__input {
    display: flex;
    align-items: center;
    height: 100%;
    flex: 1;
    justify-content: space-between;
}

input[type="text"] {
    border: none;
    outline: none;
    width: 95px;
    height: 100%;
    font-size: 13px;
    color: #333333;
    margin-left: 8px;
    flex: 1;
}
</style>
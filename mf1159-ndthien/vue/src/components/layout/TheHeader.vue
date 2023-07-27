<template>
    <div class="header">
        <div class="header__left">
            <h5 class="header__title">{{ headerResource.TitleLeft }}</h5>
        </div>
        <div class="header__right">
            <div class="header__text">{{ headerResource.TitleRight }}</div>
            <div class="header__year">
                Năm <span class="text-bold">2023</span>
                <div class="header__year--icon"></div>
            </div>
            <button
                class="header__button header__button--bell"
                :title="headerResource.NotiButton"
            ></button>
            <button
                class="header__button header__button--category"
                :title="headerResource.CategoryButton"
            ></button>
            <button
                class="header__button header__button--question"
                :title="headerResource.QuesButton"
            ></button>
            <div
                style="
                    display: flex;
                    align-items: center;
                    column-gap: 8px;
                    cursor: pointer;
                "
                :title="headerResource.ProfileButton"
            >
                <button class="header__button header__button--profile"></button>
                <button class="header__button--dropdown"></button>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "TheHeader",
    data() {
        return {
            headerResource: this.$_MISAResource.VN.Header,
        };
    },
};
</script>
<style scoped>
@import url(../../css/layout/header.css);
</style>

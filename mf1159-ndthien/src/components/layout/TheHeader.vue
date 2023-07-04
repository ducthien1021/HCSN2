<template lang="">
    <div class="header">
        <div class="header__left">
            <h5 class="header__title">Danh sách tài sản</h5>
        </div>
        <div class="header__right">
            <div class="header__text">Sở tài chính</div>
            <div class="header__year">
                Năm <span class="text-bold">2023</span>
                <div class="header__year--icon"></div>
            </div>
            <button class="header__button header__button--bell"></button>
            <button class="header__button header__button--category"></button>
            <button class="header__button header__button--question"></button>
            <div style="display: flex; align-items: center; column-gap: 8px; cursor: pointer;">
                <button class="header__button header__button--profile"></button>
                <button class="header__button--dropdown"></button>
            </div>

        </div>
    </div>
</template>
<script>
export default {
    name: 'TheHeader'
}
</script>
<style scoped>
    @import url(../../css/layout/header.css);
</style>
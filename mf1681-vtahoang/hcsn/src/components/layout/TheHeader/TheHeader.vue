<template>
    <div class="h-header">
        <div class="h-header__left">
            <div class="h-header__title">Danh sách tài sản</div>
        </div>
        <div class="h-header__right">
            <div class="h-header__btn h-header__dropdown" @click="showTM"></div>
            <div class="h-header__btn h-header__avatar" @click="showTM"></div>
            <div class="h-header__btn h-header__support" @click="showTM"></div>
            <div class="h-header__btn h-header__menu" @click="showTM"></div>
            <div class="h-header__btn h-header__notification" @click="showTM"></div>
            <div class="h-header__btn h-header__year">
                <div class="h-year__text">Năm</div>
                <div class="h-year__selected">{{ currentYear }}</div>
                <div class="h-year__icon">
                    <div class="h-year__icon--up" @click="currentYear += 1"></div>
                    <div class="h-year__icon--down" @click="currentYear -= 1"></div>
                </div>
            </div>
            <div class="h-header__department">Sở tài chính</div>
        </div>
    </div>
</template>
<style scoped>
@import url(./TheHeader.css);
</style>

<script>
export default {
    name: "TheHeader",
    methods: {
        showTM: function () {
            this.$emit("showTM");
        },
    },
    data() {
        return {
            currentYear: 2023,
        };
    },
};
</script>

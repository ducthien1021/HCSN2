<template>
    <div class="h-navbar" ref="h-navbar">
        <div class="h-navbar__logo">
            <div class="h-logo__img"></div>
            <div class="h-logo__text">MISA QLTS</div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__overview"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-overview__icon"></div>
            <div class="h-navbar__btn--text">Tổng quan</div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__assets" :class="activeClass">
            <div class="h-assets__icon"></div>
            <div class="h-navbar__btn--text">Tài sản</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__road"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-road__icon"></div>
            <div class="h-navbar__btn--text">Tài sản HT-ĐB</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__tool"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-tool__icon"></div>
            <div class="h-navbar__btn--text">Công cụ dụng cụ</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__categories"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-categories__icon"></div>
            <div class="h-navbar__btn--text">Danh mục</div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__search"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-search__icon"></div>
            <div class="h-navbar__btn--text">Tra cứu</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div
            class="h-navbar__btn--icon h-navbar__report"
            @click="showTM"
            @mouseover="hoverOn"
            @mouseout="hoverOff"
        >
            <div class="h-report__icon"></div>
            <div class="h-navbar__btn--text">Báo cáo</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__bottom" @click="navbarToggle">
            <div class="h-navbar__btn--shrink"></div>
        </div>
    </div>
</template>

<style scoped>
@import url(./TheNavbar.css);
</style>

<script>
/**
 * Ẩn hiện navbar khi click
 * Author: vtahoang - (21/06/2023)
 */
function navbarToggle() {
    try {
        const navbar = this.$refs["h-navbar"];
        navbar.classList.toggle("h-navbar--expand");
    } catch (error) {
        console.log(error);
    }
}

/**
 * Xoá trạng thái btn trên navbar khi hover btn khác
 * Author: vtahoang - (21/06/2023)
 */
function hoverOn() {
    try {
        this.activeClass = "";
    } catch (error) {
        console.log("hover ~ error:", error);
    }
}

/**
 * trả lại trạng thái btn trên navbar khi bỏ hover
 * Author: vtahoang - (21/06/2023)
 */
function hoverOff() {
    try {
        this.activeClass = "h-navbar__btn--icon--active";
    } catch (error) {
        console.log("hover ~ error:", error);
    }
}

export default {
    name: "TheNavbar",
    data() {
        return {
            activeClass: "h-navbar__btn--icon--active",
        };
    },
    methods: {
        navbarToggle,
        showTM: function () {
            this.$emit("showTM");
        },
        hoverOff,
        hoverOn,
    },
};
</script>

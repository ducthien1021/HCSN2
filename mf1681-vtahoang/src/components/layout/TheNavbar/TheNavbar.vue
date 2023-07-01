<template>
    <div class="h-navbar" ref="h-navbar">
        <div class="h-navbar__logo">
            <div class="h-logo__img"></div>
            <div class="h-logo__text">MISA QLTS</div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__overview">
            <div class="h-overview__icon"></div>
            <div class="h-navbar__btn--text">Tổng quan</div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__assets h-navbar__btn--icon--active">
            <div class="h-assets__icon"></div>
            <div class="h-navbar__btn--text">Tài sản</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__road">
            <div class="h-road__icon"></div>
            <div class="h-navbar__btn--text">Tài sản HT-ĐB</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__tool">
            <div class="h-tool__icon"></div>
            <div class="h-navbar__btn--text">Công cụ dụng cụ</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__categories">
            <div class="h-categories__icon"></div>
            <div class="h-navbar__btn--text">Danh mục</div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__search">
            <div class="h-search__icon"></div>
            <div class="h-navbar__btn--text">Tra cứu</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__btn--icon h-navbar__report">
            <div class="h-report__icon"></div>
            <div class="h-navbar__btn--text">Báo cáo</div>
            <div class="h-btn__icon--expand"></div>
        </div>
        <div class="h-navbar__bottom" @click="navbarToggle">
            <div class="h-navbar__btn--shrink"></div>
        </div>
    </div>
</template>

<style>
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
function mounted() {
    const navbarBtn = this.$el.querySelectorAll(".h-navbar__btn--icon");
    navbarBtn.forEach((btn) => {
        try {
            const currentBtn = this.$el.querySelector(".h-navbar__btn--icon--active");
            btn.addEventListener("mouseover", () => {
                currentBtn.classList.remove("h-navbar__btn--icon--active");
            });
            btn.addEventListener("mouseout", () => {
                currentBtn.classList.add("h-navbar__btn--icon--active");
            });
        } catch (error) {
            console.log(error);
        }
    });
}

const methods = {
    navbarToggle,
};

export default { methods, mounted };
</script>

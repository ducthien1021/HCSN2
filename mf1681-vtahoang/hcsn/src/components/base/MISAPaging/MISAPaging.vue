<template>
    <div class="h-paging__container">
        <div class="h-paging__recordPerPage">
            <MISADropdown
                text="20"
                :iconRight="'expand'"
                :dataList="$_MISAResources.recordPerPage"
                :dataTop="true"
                :showCheck="false"
                :inputDisable="true"
                :style="{ height: '26px', 'font-size': '12px' }"
                :itemHeight="26"
                v-model="recordPerPageValue"
                :defaultValue="20"
            />
        </div>
        <div class="h-paging__pageList" v-if="totalPage <= 0">
            <div class="h-pageblock__backicon">
                <MISAIcon :icon="'back__black'" @click="decrease"></MISAIcon>
            </div>
            <div class="h-pageblock__page" @click="select(1)" :class="selectedPage(1)">1</div>
            <div class="h-pageblock__nexticon">
                <MISAIcon :icon="'next__black'" @click="increase"></MISAIcon>
            </div>
        </div>
        <div class="h-paging__pageList" v-if="totalPage <= 5 && totalPage > 0">
            <div class="h-pageblock__backicon">
                <MISAIcon :icon="'back__black'" @click="decrease"></MISAIcon>
            </div>
            <div
                class="h-pageblock__page"
                v-for="n in totalPage"
                @click="select(n)"
                :class="selectedPage(n)"
            >
                {{ n }}
            </div>
            <div class="h-pageblock__nexticon">
                <MISAIcon :icon="'next__black'" @click="increase"></MISAIcon>
            </div>
        </div>
        <div class="h-paging__pageList" v-if="totalPage > 5">
            <div class="h-pageblock__backicon">
                <MISAIcon :icon="'back__black'" @click="decrease"></MISAIcon>
            </div>
            <div class="h-pageblock__page" @click="select(1)" :class="selectedPage(1)">1</div>
            <div
                class="h-pageblock__page"
                @click="select(afterFirst)"
                :class="selectedPage(afterFirst)"
            >
                {{ afterFirst }}
            </div>
            <div class="h-pageblock__page" @click="select(middle)" :class="selectedPage(middle)">
                {{ middle }}
            </div>
            <div
                class="h-pageblock__page"
                @click="select(beforeLast)"
                :class="selectedPage(beforeLast)"
            >
                {{ beforeLast }}
            </div>
            <div
                class="h-pageblock__page"
                @click="select(totalPage)"
                :class="selectedPage(totalPage)"
            >
                {{ totalPage }}
            </div>

            <div class="h-pageblock__nexticon">
                <MISAIcon :icon="'next__black'" @click="increase"></MISAIcon>
            </div>
        </div>
    </div>
</template>

<style scoped>
@import url(./MISAPaging.css);
</style>

<script>
import MISADropdown from "../MISADropdown/MISADropdown.vue";
import MISAIcon from "../MISAIcon/MISAIcon.vue";

/**
 * Sang trang tiếp theo
 * Author: vtahoang (11/07/2021)
 */
function increase() {
    try {
        if (this.currentPage < this.totalPage) this.currentPageValue += 1;
    } catch (error) {
        console.log("increase ~ error:", error);
    }
}

/**
 * Về trang trước đó
 * Author: vtahoang (11/07/2021)
 */
function decrease() {
    try {
        if (this.currentPage > 1) this.currentPageValue -= 1;
    } catch (error) {
        console.log("decrease ~ error:", error);
    }
}

/**
 * Tô viền page hiện tại
 * @param {*} page
 * Author: vtahoang (11/07/2021)
 */
function selectedPage(page) {
    try {
        if (page === this.currentPage) return "h-pageblock__page--selected";
        return "";
    } catch (error) {
        console.log("selectedPage ~ error:", error);
    }
}

/**
 * Chọn page click vào
 * @param {*} page
 * Author: vtahoang (11/07/2021)
 */
function select(page) {
    try {
        if (page === "...") return;
        this.currentPageValue = page;
    } catch (error) {
        console.log("select ~ error:", error);
    }
}

export default {
    name: "MISAPaging",
    components: {
        MISADropdown,
        MISAIcon,
    },
    props: {
        totalRecord: { type: Number, default: 0 }, // Tổng số bản ghi
        recordPerPage: { Number, default: 20 }, // Số bản ghi trên 1 trang
        currentPage: { Number, default: 1 }, // Trang hiện tại
    },
    data() {
        return {
            recordPerPageValue: this.recordPerPage, // Số bản ghi trên 1 trang
            currentPageValue: this.currentPage, // Trang hiện tại
            totalPage: Math.ceil(this.totalRecord / this.recordPerPage), // Tổng số trang
            beforeLast: "...", // Ký tự hiển thị trước trang cuối
            afterFirst: 2, // Ký tự hiển thị sau trang đầu
            middle: 3, // Ký tự hiển thị ở giữa
        };
    },
    watch: {
        recordPerPageValue: function (value) {
            this.$emit("update:recordPerPage", value);
        },
        currentPageValue: function (value) {
            this.$emit("update:currentPage", value);
        },
        currentPage: function (value) {
            this.currentPageValue = value;
            if (this.currentPage < this.totalPage - 2) {
                this.beforeLast = "...";
            } else {
                this.beforeLast = this.totalPage - 1;
            }
            if (this.currentPage > 3) {
                this.afterFirst = "...";
            } else {
                this.afterFirst = 2;
            }
            if (this.currentPage > 3 && this.currentPage <= this.totalPage - 3)
                this.middle = this.currentPage;
            else if (this.currentPage >= this.totalPage - 3) this.middle = this.totalPage - 2;
            else this.middle = 3;
        },
        recordPerPage: function (value) {
            this.recordPerPageValue = value;
            this.totalPage = Math.ceil(this.totalRecord / this.recordPerPage);
            this.currentPageValue = 1;
        },
        totalRecord: function () {
            this.totalPage = Math.ceil(this.totalRecord / this.recordPerPage);
            this.currentPageValue = 1;
        },
    },
    methods: {
        increase,
        decrease,
        selectedPage,
        select,
    },
    computed: {},
};
</script>

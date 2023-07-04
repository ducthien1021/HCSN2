<template lang="">
    <div class="pagination">
        <div class="pagination__total-record">
            Tổng số:
            <span class="text-bold" style="font-size: 12px">
                {{ totalRecord }}
            </span>
            bản ghi
        </div>
        <div class="pagination__page-size"></div>
        <div class="pagination__page-number">
            <ul class="page-number">
                <button
                    class="page-number__item page-number__icon icon--prev"
                    @click="toPrevPage()"
                    :disabled="isFirstPage()"
                ></button>
                <li
                    class="page-number__item"
                    :class="{
                        'page-number__item--active': currentPageNumber == page,
                    }"
                    v-for="(page, index) in pageNumber"
                    :key="index"
                    @click="toPage(page)"
                >
                    {{ page }}
                </li>
                <button
                    class="page-number__item page-number__icon icon--next"
                    @click="toNextPage()"
                    :disabled="isLastPage()"
                ></button>
            </ul>
        </div>
    </div>
</template>
<script>
export default {
    name: "MISAPagination",
    props: {
        totalRecord: {
            type: Number,
            required: true,
            default: 0,
        },
    },
    data() {
        return {
            pageSize: 20, // Tổng số bản ghi trên một trang
            currentPageNumber: 1, // Số trang hiện tại
            dataRecord: [
                { pageSize: 10 },
                { pageSize: 20 },
                { pageSize: 30 },
                { pageSize: 50 },
                { pageSize: 100 },
            ],
            dataRecordFields: { value: "pageSize", text: "pageSize" },
        };
    },
    methods: {
        /**
         * Chuyển trang trước
         * Author: NDThien 1/7/2023
         */
        toPrevPage() {
            if (!this.isFirstPage()) {
                this.currentPageNumber--;
            }
        },
        /**
         * Chuyển trang tiếp theo
         * Author: NDThien 1/7/2023
         */
        toNextPage() {
            if (!this.isLastPage()) {
                this.currentPageNumber++;
            }
        },
        /**
         * Chuyển tới trang được chỉ định
         * Author: NDThien 1/7/2023
         * @param {*} page: Số trang thực hiện chuyển đến
         */
        toPage(page) {
            if (page === "...") {
                return;
            }
            this.currentPageNumber = page;
        },
        /**
         * Kiểm tra trang hiện tại có phải trang đầu tiên
         * Author: NDThien 1/7/2023
         */
        isFirstPage() {
            return this.currentPageNumber == 1;
        },
        /**
         * Kiểm tra trang hiện tại có phải trang cuối cùng
         * Author: NDThien 1/7/2023
         */
        isLastPage() {
            return this.currentPageNumber == this.totalPage;
        },
    },

    computed: {
        /**
         * Tính toán tổng số trang
         * Author: NDThien 1/7/2023
         */
        totalPage() {
            return Math.ceil(this.totalRecord / this.pageSize);
        },
        /**
         * Tính toán hiển thị danh sách số trang
         * Auhtor: NDThien 1/7/2023
         */
        pageNumber() {
            let pageNumber = [];
            for (let i = 1; i <= this.totalPage; ++i) {
                if (
                    i == 1 ||
                    i == this.totalPage ||
                    (i <= this.currentPageNumber + 2 &&
                        i >= this.currentPageNumber - 2)
                ) {
                    pageNumber.push(i);
                } else if (
                    i == this.currentPageNumber + 3 ||
                    i == this.currentPageNumber - 3
                ) {
                    pageNumber.push("...");
                }
            }
            return pageNumber;
        },
    },
};
</script>
<style>
@import url(../../css/base/pagination.css);
</style>

<template lang="">
    <div class="combobox" ref="combobox" :class="className">
        <span
            class="combobox__icon combobox__icon--filter"
            @click="showData()"
            v-if="iconFilter == true"
        ></span>
        <input
            type="text"
            class="combobox__input"
            :class="{
                'pd-left-14': iconFilter == false,
                'pd-left-35': iconFilter == true,
            }"
            ref="combobox__input"
            v-model="valueTextInput"
            @input="filterData()"
            @keydown="onKeyDown"
            :placeholder="placeholder"
            :tabindex="tabindex"
            @blur="onBlurCombobox"
        />
        <span
            class="combobox__icon combobox__icon--arrow-down"
            @click="toggleCombobox()"
        ></span>
        <div class="combobox__data" v-if="isShowData">
            <a class="combobox__data--item" v-if="filteredData.length === 0">
                <span class="combobox__data--text"
                    >Không tìm thấy dữ liệu!</span
                >
            </a>
            <a
                v-for="(item, index) in filteredData"
                :key="item[dataFields['value']]"
                class="combobox__data--item"
                :class="{
                    'combobox__data--active':
                        (isSelectedItem(item) && indexSelected == null) ||
                        indexSelected == index,
                }"
                @click="onSelectDataItem(item)"
            >
                <span
                    class="combobox__data--icon-active"
                    v-if="isSelectedItem(item)"
                ></span>
                <span class="combobox__data--text">{{
                    dataFields ? item[dataFields["text"]] : item
                }}</span>
            </a>
        </div>
    </div>
</template>
<script>
export default {
    name: "MISACombobox",
    emits: ["update:modelValue"],
    props: {
        /**
         * Prop xác định xem có sử dụng icon filter không
         */
        iconFilter: {
            type: Boolean,
            required: false,
            default: false,
        },
        /**
         * Array data cho combobox
         */
        dataSource: {
            type: Array,
            required: true,
            default: null,
        },
        /**
         *  Object mang thông tin value, text cho combobox
         */
        dataFields: {
            type: Object,
            required: true,
            default: null,
        },
        placeholder: {
            type: String,
            required: true,
            default: "",
        },
        tabindex: {
            type: Number,
            required: false,
            default: null,
        },
        modelValue: {
            type: [String, Boolean, Number, Array, Object],
            required: true,
            default: null,
        },
        className: {
            type: String,
            required: false,
            default: null,
        },
    },
    data() {
        return {
            isShowData: false, // Trạng thái ẩn/hiện data
            data: [], // Data gốc
            filteredData: [], // Data đã được filter để thực hiện show data
            itemSelected: {}, // Item đang được chọn
            valueTextInput: "", // Value text được hiển thị trên input của combobox
            indexSelected: null, // Index item đang được chọn
        };
    },
    created() {
        this.data = this.dataSource;
        this.filteredData = this.dataSource;
    },
    mounted() {
        // Gắn lắng nghe sự kiện click cho toàn bộ trang
        document.addEventListener("click", this.handleClickOutside);
    },
    beforeUnmount() {
        // Gỡ lắng nghe sự kiện click khi component bị hủy
        document.removeEventListener("click", this.handleClickOutside);
    },
    methods: {
        /**
         * Toggle dropdown data combobox
         * Author: ND Thien 29/06/2023
         */
        toggleCombobox() {
            this.isShowData = !this.isShowData;
            if (this.isShowData) {
                this.$nextTick(function () {
                    this.$refs["combobox__input"].focus();
                });
                this.indexSelected = null; // Reset index selected khi hiện data
            }
        },
        /**
         * Hiện dropdown data
         * Author: ND Thien 29/06/2023
         */
        showData() {
            this.isShowData = true;
        },
        /**
         * Ẩn dropdown data
         * Author: ND Thien 29/06/2023
         */
        hideData() {
            this.isShowData = false;
        },
        /**
         * Update phần tử được chọn và thực hiện setup binding 2 chiều
         * @param {*} item: Phần tử được chọn
         * Author: ND Thien 29/06/2023
         */
        onSelectDataItem(item) {
            this.itemSelected = item;
            this.valueTextInput = this.itemSelected
                ? this.itemSelected[this.dataFields["text"]]
                : "";

            // Binding 2 chiều
            this.$emit(
                "update:modelValue",
                this.itemSelected[this.dataFields["value"]]
            );
            this.hideData();
        },
        /**
         * Kiểm tra phần tử có phải đang được chọn hay không
         * @param {*} item: phần tử kiểm tra
         * @returns True: nếu item là phần tử đang được chọn, False: ngược lại
         * Author: ND Thien 29/06/2023
         */
        isSelectedItem(item) {
            return JSON.stringify(this.itemSelected) === JSON.stringify(item);
        },
        /**
         * Thực hiện filter data, str.includes("") == true vì String luôn luôn có chuỗi rỗng
         * Author: ND Thien 29/06/2023
         */
        filterData() {
            this.showData();
            this.filteredData = this.data.filter((item) =>
                item[this.dataFields["text"]].includes(this.valueTextInput)
            );
        },
        /**
         * Xử lý Up, Down, Enter để lựa chọn item
         * Author: ND Thien 29/06/2023
         */
        onKeyDown() {
            const keyCode = event.keyCode;
            const maxIndex = this.filteredData.length - 1;
            switch (keyCode) {
                case 40:
                    if (this.isShowData) {
                        if (
                            this.indexSelected == null ||
                            this.indexSelected >= maxIndex
                        ) {
                            this.indexSelected = 0;
                        } else {
                            this.indexSelected++;
                        }
                    } else {
                        this.indexSelected == null;
                    }
                    this.showData();
                    break;
                case 38:
                    if (this.isShowData) {
                        if (
                            this.indexSelected == null ||
                            this.indexSelected <= 0
                        ) {
                            this.indexSelected = maxIndex;
                        } else {
                            this.indexSelected--;
                        }
                    } else {
                        this.indexSelected == null;
                    }
                    this.showData();

                    break;
                case 13:
                    if (this.indexSelected != null) {
                        this.onSelectDataItem(
                            this.filteredData[this.indexSelected]
                        );
                        this.hideData();
                    }
                    break;
            }
        },
        /**
         * Kiểm tra click outside thì ẩn data dropdown
         * Author: ND Thien 29/06/2023
         */
        handleClickOutside() {
            // Kiểm tra xem sự kiện click có xảy ra bên ngoài phần tử container hay không
            if (!this.$refs["combobox"].contains(event.target)) {
                this.hideData();
                // Trương hợp xóa hết text trong input thì khi click outside sẽ fill lại item đã chọn
                if (this.valueTextInput == "") {
                    this.valueTextInput = this.itemSelected
                        ? this.itemSelected[this.dataFields["text"]]
                        : "";
                }
            }
        },
        /**
         * Gửi thông tin cho parent để biết rằng input combobox on blur
         * Author: ND Thien 29/06/2023
         */
        onBlurCombobox() {
            this.$emit("blur");
        },
    },
};
</script>
<style>
@import url(../../css/base/combobox.css);
</style>

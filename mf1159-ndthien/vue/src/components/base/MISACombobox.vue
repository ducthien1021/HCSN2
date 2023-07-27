<template>
    <div
        class="combobox"
        ref="combobox"
        :class="[className, isError ? 'cbx--error' : '']"
    >
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
            :disabled="!autoComplete"
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
        <div
            class="combobox__data"
            :class="[`combobox__data--${positionData}`]"
            v-if="isShowData"
        >
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
                @mousedown="onSelectDataItem(item)"
            >
                <span
                    class="combobox__data--icon-active"
                    v-if="isSelectedItem(item) && iconCheckItem"
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
        isError: {
            type: Boolean,
            required: false,
            default: false,
        },
        placeholder: {
            type: String,
            required: false,
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
        positionData: {
            // Xác định vị trí hiển thị của dropdown data: top, bottom
            type: String,
            required: false,
            default: "bottom",
        },
        iconCheckItem: {
            // Xác định item data có icon check hay không
            type: Boolean,
            required: false,
            default: true,
        },
        autoComplete: {
            // Combobox có cho autocomplete (search filter value) hay không
            type: Boolean,
            required: false,
            default: true,
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
    watch: {
        /**
         * Theo dõi 2way binding truyền từ ngoài để cập nhật component
         * Author: NDThien 17/07/2023
         */
        modelValue: {
            handler() {
                // Set data binding từ ngoài vào
                this.setDataBinding();
            },
            deep: true,
        },
    },
    created() {
        // Khởi tạo data
        this.data = this.dataSource;
        this.filteredData = this.dataSource;

        // Set data binding từ ngoài vào
        this.setDataBinding();
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

            // Nếu Input rỗng thì reset(xóa) item đang được chọn
            if (this.valueTextInput == "") {
                this.itemSelected = {};
                this.$emit("update:modelValue", "");
            }
        },
        /**
         * Xử lý Up, Down, Enter để lựa chọn item
         * Author: ND Thien 29/06/2023
         */
        onKeyDown() {
            const keyCode = event.keyCode;
            const maxIndex = this.filteredData.length - 1;
            switch (keyCode) {
                case this.$_MISAEnum.KeyCode.Down:
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
                case this.$_MISAEnum.KeyCode.Up:
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
                case this.$_MISAEnum.KeyCode.Enter:
                    if (this.indexSelected != null) {
                        this.onSelectDataItem(
                            this.filteredData[this.indexSelected]
                        );
                        this.onBlurCombobox();
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
         * Gửi thông tin cho parent để biết rằng input combobox on blur và ẩn dropdown data
         * Author: ND Thien 29/06/2023
         */
        onBlurCombobox() {
            this.hideData();
            this.$emit("blur");
        },
        /**
         * Hàm set data binding được truyền từ ngoài để thực hiện chọn data trong combobox
         * Author: NDThien 27/07/2023
         */
        setDataBinding() {
            // Set item selected được 2way binding từ ngoài vào
            if (this.modelValue) {
                const index = this.data.findIndex(
                    (item) => item[this.dataFields["value"]] === this.modelValue
                );
                this.itemSelected = this.data[index];
                // Cập nhật text của item được chọn lên combobox
                this.valueTextInput = this.itemSelected
                    ? this.itemSelected[this.dataFields["text"]]
                    : "";
            }
        },
    },
};
</script>
<style scoped>
@import url(../../css/base/combobox.css);
</style>

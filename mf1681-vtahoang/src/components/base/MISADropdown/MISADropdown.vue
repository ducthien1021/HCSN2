<template>
    <div class="container" @click="showDataList" tabindex="0" @focusout="hideDataList">
        <label v-if="label">{{ label }} <span v-if="required">*</span></label>
        <div ref="dropdown" class="h-dropdown">
            <div v-if="iconLeft" class="h-dropdown__icon">
                <MISAIcon :icon="iconLeft" />
            </div>
            <input
                ref="input"
                class="h-dropdown__current"
                :placeholder="text"
                v-model="currentValue"
            />
            <div v-if="iconRight" class="h-dropdown__expand">
                <MISAIcon :icon="iconRight" />
            </div>
        </div>
        <div
            v-show="showList"
            class="h-dropdown__dataList"
            @mouseover="mouseover = true"
            @mouseout="mouseover = false"
        >
            <div
                class="h-dataList__item"
                v-for="(item, index) in dataList"
                :key="index"
                @click="itemClick(item)"
            >
                <div class="h-item__check">
                    <div class="check-icon"></div>
                </div>
                <div class="h-item__name">{{ item }}</div>
            </div>
        </div>
    </div>
</template>

<style scoped>
@import url(./MISADropdown.css);
</style>

<script>
import MISAIcon from "../MISAIcon/MISAIcon.vue";

/**
 * Hiển thị danh sách dữ liệu khi click vào dropdown
 * Author: vtahoang (04/07/2023)
 */
function showDataList() {
    try {
        if (!this.mouseover) {
            this.$refs.input.focus();
            this.showList = true;
        }
    } catch (error) {
        console.log(error);
    }
}

/**
 * Ẩn danh sách dữ liệu khi click ra ngoài
 * Author: vtahoang (04/07/2023)
 */
function hideDataList() {
    try {
        if (!this.mouseover) {
            this.showList = false;
        }
    } catch (error) {
        console.log("hideDataList ~ error:", error);
    }
}

/**
 * Xử lý khi click vào 1 item trong danh sách
 * @param {*} item thẻ được click
 * Author: vtahoang (04/07/2023)
 */
function itemClick(item) {
    try {
        //xóa class selected của các item khác
        let items = this.$el.querySelectorAll(".h-dataList__item");
        items.forEach((item) => {
            item.classList.remove("selected");
        });
        //thêm class selected cho item được click
        event.currentTarget.classList.add("selected");
        this.currentValue = item;
        //ẩn danh sách
        this.showList = false;
    } catch (error) {
        console.log("itemClick ~ error:", error);
    }
}

export default {
    data() {
        // nếu có giá trị ban đầu thì gán giá trị ban đầu cho currentValue
        let currentValue;
        if (this.modelValue) {
            currentValue = this.modelValue;
        }
        return {
            showList: false, //hiển thị data list
            currentValue, //giá trị hiện tại của dropdown
            mouseover: false, // chuột đang trên data list
        };
    },
    props: {
        // nhãn
        label: {
            type: String,
            default: "",
        },
        // bắt buộc nhập
        required: {
            type: Boolean,
            default: false,
        },
        // placeholder
        text: {
            type: String,
            default: "",
        },
        // danh sách dữ liệu
        dataList: {
            type: Object,
            default: () => {},
        },
        // giá trị ban đầu
        modelValue: "",
        // icon trái
        iconLeft: {
            type: String,
            default: "",
        },
        // icon phải
        iconRight: {
            type: String,
            default: "",
        },
    },
    components: {
        MISAIcon,
    },
    watch: {
        // khi modelValue thay đổi thì gán giá trị mới cho currentValue
        modelValue: function () {
            this.currentValue = this.modelValue;
        },
        // khi currentValue thay đổi thì gán giá trị mới cho modelValue
        currentValue: function () {
            this.$emit("update:modelValue", this.currentValue);
        },
    },
    methods: { itemClick, showDataList, hideDataList },
};
</script>

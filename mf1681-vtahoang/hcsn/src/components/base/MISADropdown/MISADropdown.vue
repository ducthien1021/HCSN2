<template>
    <div
        ref="container"
        class="container"
        :tabindex="0"
        @focusout="hideDataList"
        :style="style"
        @keydown="selectWithKey"
        @mousemove="dataFocus = -1"
    >
        <label v-if="label">{{ label }} <span v-if="required">*</span></label>
        <div ref="dropdown" class="h-dropdown" @click="showDataList">
            <div v-if="iconLeft" class="h-dropdown__icon">
                <MISAIcon :icon="iconLeft" />
            </div>
            <input
                ref="input"
                class="h-dropdown__current"
                :placeholder="text"
                v-model="currentValue"
                :tabindex="tabindex"
                :disabled="inputDisable"
            />
            <div v-if="iconRight" class="h-dropdown__expand">
                <MISAIcon :icon="iconRight" />
            </div>
            <div v-if="errormsg" class="h-dropdown__errormsg">{{ errormsg }}</div>
        </div>
        <div
            v-show="showList"
            class="h-dropdown__dataList"
            @mouseover="mouseover = true"
            @mouseleave="mouseover = false"
            :class="dataTop ? 'h-dropdown__dataList--top' : ''"
            ref="dataList"
        >
            <div
                class="h-dataList__item"
                :class="selectedItem(item, index)"
                v-for="(item, index) in dataListShown"
                :key="index"
                @click="itemClick(item)"
                :style="itemStyle"
            >
                <div v-if="showCheck" class="h-item__check">
                    <div class="check-icon"></div>
                </div>
                <div class="h-item__name">{{ item }}</div>
            </div>
            <div class="h-dataList__item h-item__empty" v-if="empty" @click="itemClick('empty')">
                <div class="h-item__name">- - Không có dữ liệu phù hợp - -</div>
            </div>
            <div class="h-dataList__item h-item__loading" v-if="isLoading">
                <MISAIcon icon="loading" :style="{ width: '40px', height: '40px' }"></MISAIcon>
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
        this.$refs.input.focus();
        this.showList = true;
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
        // nếu item được chọn là item hiện tại hoặc ô dữ liệu trống thì xoá giá trị
        if (this.currentValue == item || item == "empty") this.currentValue = this.defaultValue;
        // ngược lại thì cập nhật lại giá trị
        else {
            this.currentValue = item;
        }
        //ẩn danh sách
        this.showList = false;
        this.mouseover = false;
    } catch (error) {
        console.log("itemClick ~ error:", error);
    }
}

/**
 *  Kiểm tra item có được chọn hay không
 * @param {*} value gias trị của item
 * Author: vtahoang (04/07/2023)
 */
function selectedItem(value, index) {
    let addClass = "";
    if (index == this.dataFocus) {
        addClass += "focus ";
    }
    if (value == this.currentValue) {
        addClass += "selected";
    }
    return addClass;
}

/**
 * Validate dữ liệu
 * @param {String} value giá trị của input
 * Author: vtahoang (04/07/2023)
 */
function validator(value) {
    try {
        if (this.required && (value == "" || value == null || value == undefined)) {
            return "Trường này không được để trống";
        }
        if (this.required && !Object.values(this.dataList).includes(value)) {
            return "Trường này không hợp lệ";
        }

        return "";
    } catch (error) {
        console.log(error);
        return "";
    }
}

/**
 * kiểm tra đã hợp lệ chưa
 * Author: vtahoang (04/07/2023)
 */
function isValid() {
    try {
        let value = this.currentValue;
        // error message khi validate dữ liệu
        this.errormsg = this.validator(value);
        // cập nhật lại error message
        this.$emit("update:modeErrormsg", this.errormsg);
        if (!this.errormsg) {
            // không có lỗi thì cập nhật lại giá trị và xoá class error
            if (Object.values(this.dataList).includes(value) || value == "") {
                // giá trị hợp lệ
                this.$emit("update:modelValue", value);
            }
            this.$refs.container.classList.remove("h-dropdown--error");
            return true;
        } else {
            // có lỗi thì thêm class error
            this.$refs.container.classList.add("h-dropdown--error");
            return false;
        }
    } catch (error) {
        console.log(error);
        return false;
    }
}

/**
 * lọc danh sách chọn
 * Author: vtahoang (09/07/2023)
 */
function shownList() {
    try {
        // debugger;
        if (this.filterValue != "" && this.filterValue != null && this.filterValue != undefined) {
            this.dataListShown = Object.values(this.dataList).filter((item) => {
                return item
                    .toString()
                    .toLowerCase()
                    .includes(this.filterValue.toString().toLowerCase());
            });
        } else this.dataListShown = this.dataList;
        if (this.dataListShown.length <= 0) {
            this.empty = true;
        } else this.empty = false;
    } catch (error) {
        console.log("shownList ~ error:", error);
    }
}

/**
 * Di chuyển với button
 * Author: vtahoang (11/07/2023)
 */
function selectWithKey() {
    try {
        if (event.keyCode == this.$_MISAEnum.keyCode.keyDown) {
            if (this.dataFocus < Object.values(this.dataListShown).length) {
                this.dataFocus++;
            }
        }
        if (event.keyCode == this.$_MISAEnum.keyCode.keyUp) {
            if (this.dataFocus >= 0) {
                this.dataFocus--;
            }
        }
        if (event.keyCode == this.$_MISAEnum.keyCode.enter) {
            let data = Object.values(this.dataListShown)[this.dataFocus];
            if (this.currentValue == data) {
                this.currentValue = this.defaultValue;
            } else this.currentValue = Object.values(this.dataListShown)[this.dataFocus];
            this.showList = !this.showList;
        }
        this.$refs.dataList.scrollTop = (this.dataFocus - 5) * 36;
    } catch (error) {
        console.log("selectWithKey ~ error:", error);
    }
}

export default {
    data() {
        let currentValue;
        if (this.modelValue) {
            currentValue = this.modelValue;
        }
        return {
            showList: false, //hiển thị data list
            currentValue, // giá trị hiện tại của dropdown
            mouseover: false, // chuột đang trên data list
            errormsg: "", // thông báo lỗi
            dataListShown: this.dataList, // danh sách hiển thị
            // giá trị lọc
            filterValue: "",
            // danh sách hiển thị trống
            empty: false,
            // index dữ liệu đang được focus
            dataFocus: -1,
            // style của item
            itemStyle: {
                flex: `0 0 ${this.itemHeight}px`,
            },
            // trạng thái loading
            isLoading: true,
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
        // thứ tự tab
        tabindex: {
            type: Number,
            default: 0,
        },
        //data list hiện lên trên
        dataTop: {
            type: Boolean,
            default: false,
        },
        //hiện check trên dataList
        showCheck: {
            type: Boolean,
            default: true,
        },
        //disable input
        inputDisable: {
            type: Boolean,
            default: false,
        },
        //style
        style: {
            type: Object,
            default: () => {},
        },
        // height của item
        itemHeight: {
            type: Number,
            default: null,
        },
        //giá trị mặc định khi không có dữ liệu
        defaultValue: {
            default: "",
        },
    },
    components: {
        MISAIcon,
        MISAIcon,
    },
    watch: {
        currentValue(value) {
            if (this.isValid()) {
                if (Object.values(this.dataList).includes(value) || value == "") {
                    // giá trị hợp lệ
                    this.$emit("update:modelValue", value);
                }
            }
            //cập nhật lại danh sách hiển thị
            if (Object.values(this.dataListShown).includes(value)) {
                this.filterValue = "";
                this.mouseover = true;
            } else {
                this.mouseover = false;
                this.filterValue = value;
            }
            this.shownList();
        },
        modelValue(value) {
            this.currentValue = value;
        },
    },
    methods: {
        itemClick,
        showDataList,
        hideDataList,
        validator,
        isValid,
        selectedItem,
        shownList,
        selectWithKey,
    },
    updated() {
        if (Object.keys(this.dataList).length > 0) {
            this.isLoading = false;
        }
    },
};
</script>

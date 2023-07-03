<template>
    <div class="filter" @click="onFocus" v-on-click-outside="onBlur" :class="{ input__error: isRequired && isInvalid }">
        <div class="filter__icon" v-if="icons === true">
            <MISAIcon :pX="this.$_icons.filter.pX" :pY="this.$_icons.filter.pY" :width="this.$_icons.filter.width"
                :height="this.$_icons.filter.height" :boxHeight="this.$_icons.filter.boxHeight"
                :boxWidth="this.$_icons.filter.boxWidth" :scale="this.$_icons.filter.scale" />
        </div>
        <div class="filter__input">
            <input type="text" :placeholder="placeholder" v-model="selectedOption.text" @input="onInput"
                @keydown.enter="onEnter" readonly @keydown.up.prevent @keydown.down.prevent :required="required" />
            <MISAIcon style="pointer-events: none;" :pX="this.$_icons.arrowDown.pX" :pY="this.$_icons.arrowDown.pY"
                :width="this.$_icons.arrowDown.width" :height="this.$_icons.arrowDown.height"
                :scale="this.$_icons.arrowDown.scale" />
        </div>
        <div class="f-data-list" v-show="isExpanded">
            <div class="f-data-list__item" v-for="(option, index) in filteredOptions" :key="index"
                :class="{ 'f-data-list__item--active': index === activeIndex }" @mouseover="activeIndex = index"
                @mousedown="onOptionClick(option)">
                <MISAIcon class="select-icon" :pX="this.$_icons.tick.pX" :pY="this.$_icons.tick.pY"
                    :width="this.$_icons.tick.width" :height="this.$_icons.tick.height"
                    :filter="this.$_icons.tick.filter" />
                <p>{{ option.text }}</p>
            </div>
        </div>
        <span v-if="isRequired && isInvalid" class="error">
            Please select a value.
        </span>
    </div>
</template>
  
<script>
import MISAIcon from "../icon/MISAIcon.vue";
import { vOnClickOutside } from '@vueuse/components'
export default {

    name: "MISASelectInput",
    components: {
        MISAIcon,
    },
    directives: {
        onClickOutside: vOnClickOutside, // v-on-click-outside -> onClickOutside
    },
    props: {
        /**
         * @description: Danh sách các option
         */
        options: {
            type: Array,
            required: true,
        }, 
        /**
         * @description: Placeholder của input
         */
        placeholder: {
            type: String,
            default: "",
        },
        /** 
         * @description: Có hiển thị icon hay không
         */
        icons: {
            type: Boolean,
            default: true,
        },
        /**
         * @description: Có bắt buộc nhập hay không
         */
        isRequired: {
            type: Boolean,
            default: false,
        },
    },
    data() {
        return {
            isExpanded: false, // Trạng thái mở rộng của input
            isFocused: true, // Trạng thái focus của input
            selectedOption: { value: "", text: "" }, // Option được chọn
            filteredOptions: [ // Danh sách option được lọc
                { value: '1', text: 'Tài sản 1' },
                { value: '2', text: 'Tài sản 2' },
                { value: '3', text: 'Tài sản 3' },
                { value: '4', text: 'Tài sản 4' },
                { value: '5', text: 'Tài sản 5' },
                { value: '6', text: 'Tài sản 6' },
                { value: '7', text: 'Tài sản 7' },
                { value: '8', text: 'Tài sản 8' },
            ],
            activeIndex: 0, // Index của option đang được chọn
        };
    },
    computed: {
        /**
         * @description: Kiểm tra input có hợp lệ hay không
         * @param {*}
         * @return {*}
         * @rely: isFocused, selectedOption
         * @emit: none
         * @call: none
         * @calledBy: isInvalid
         * Author: PQNAM (26/06/2023)
         */
        isInvalid() {
            return !this.isFocused && !this.selectedOption.text;
        },
    },
    methods: {
        /**
         * @description: Sự kiện focus vào input
         * @param {*}
         * @return {*}
         * @rely: isExpanded
         * @emit: none
         * @call: none
         * @calledBy: onFocus
         * Author: PQNAM (26/06/2023)
         */
        onFocus() {
            this.isExpanded = !this.isExpanded;
            this.isFocused = true;
        },

        /**
         * @description: Sự kiện blur khỏi input
         * @param {*}
         * @return {*}
         * @rely: isExpanded
         * @emit: none
         * @call: none
         * @calledBy: onBlur
         * Author: PQNAM (26/06/2023)
         */
        onBlur() {
            this.isExpanded = false;
            this.isFocused = false;
        },

        /**
         * @description: Sự kiện khi nhập vào input
         * @param {*}
         * @return {*}
         * @rely: filteredOptions, activeIndex
         * @emit: none
         * @call: none
         * @calledBy: onInput
         * Author: PQNAM (26/06/2023)
         */
        onInput() {
            this.filteredOptions = this.options.filter((option) =>
                option.text.toLowerCase().includes(this.selectedOption.text.toLowerCase())
            );
            this.activeIndex = 0;
        },

        /**
         * @description: Sự kiện khi nhấn enter
         * @param {*}
         * @return {*}
         * @rely: selectedOption, isExpanded
         * @emit: optionSelected
         * @call: none
         * @calledBy: onEnter
         * Author: PQNAM (26/06/2023)
         */
        onEnter() {
            this.selectedOption = this.filteredOptions[this.activeIndex];
            this.isExpanded = false;
            this.$emit("optionSelected", this.selectedOption);
        },

        /**
         * @description: Sự kiện khi click vào option
         * @param {*}
         * @return {*}
         * @rely: selectedOption, isExpanded
         * @emit: optionSelected
         * @call: none
         * @calledBy: onOptionClick
         * Author: PQNAM (26/06/2023)
         */
        onOptionClick(option) {
            this.selectedOption = option;
            this.isExpanded = false;
            this.$emit("optionSelected", this.selectedOption);
        },
    },
};
</script>
  
<style scoped>
.filter {
    display: flex;
    align-items: center;
    width: 220px;
    height: 36px;
    border-radius: 3px;
    background-color: #ffffff;
    border: 1px solid #ebeef5;
    padding: 6px;
    box-sizing: border-box;
    position: relative;
    flex-wrap: wrap;
}

.filter.input__error {
    border: 1px solid #fe4609;
}

.filter:hover,
.filter:focus-within {
    border: 1px solid #007bff;
}

.filter:hover .f-data-list {
    visibility: visible;
}

.filter:hover .f-data-list {
    display: block;
}

.filter__icon {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 24px;
    height: 24px;
    pointer-events: none;
}

.filter__input {
    display: flex;
    align-items: center;
    height: 100%;
    flex: 1;
    justify-content: space-between;
}

input[type="text"] {
    border: none;
    outline: none;
    width: 95px;
    height: 100%;
    font-size: 13px;
    color: #333333;
    margin-left: 8px;
    flex: 1;
}

.f-data-list {
    position: absolute;
    width: 100%;
    height: auto;
    max-height: 252px;
    overflow: auto;
    left: 0;
    top: 37px;
    background-color: #fff;
    border-radius: 3px;
    box-shadow: 0px 0px 0px 1px #ebeef5;
    display: block;
    padding: 4px;
    box-sizing: border-box;
    z-index: 2;
}

/* Ẩn mũi tên trên thanh cuộn trên Chrome và Safari */
.f-data-list::-webkit-scrollbar {
    width: 8px;
    /* Độ rộng của thanh cuộn */
}

.f-data-list::-webkit-scrollbar-track {
    background-color: #f1f1f1;
    /* Màu nền của thanh cuộn */
}

.f-data-list::-webkit-scrollbar-thumb {
    background-color: #888;
    /* Màu của thanh cuộn */
    border-radius: 50px;
    /* Độ cong của đầu thanh cuộn */
}

.f-data-list::-webkit-scrollbar-thumb:hover {
    background-color: #555;
    /* Màu của thanh cuộn khi hover */
}

.f-data-list__item {
    display: flex;
    align-items: center;
    height: 36px;
    box-sizing: border-box;
    cursor: pointer;
    border-radius: 3px;
}

.f-data-list__item:active {
    background-color: var(--row-hover-color);
}

.f-data-list__item--active {
    background-color: var(--row-hover-color);
}

.f-data-list__item--active .select-icon {
    visibility: visible;
}



.select-icon {
    visibility: hidden;
}

p {
    font-size: 13px;
    margin-left: 12px;
}

input::placeholder {
    font-style: italic;
}

.error {
    color: red;
    font-size: 12px;
    margin-left: 5px;
    margin-top: 1px
}</style>


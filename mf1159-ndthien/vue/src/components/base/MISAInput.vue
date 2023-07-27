<template>
    <div class="input-wrapper" :class="isError ? 'input--error' : ''">
        <div
            v-if="prefixIcon !== ''"
            class="input__icon"
            :class="`input__icon--${prefixIcon}`"
        ></div>
        <input
            ref="misaInput"
            type="text"
            class="input"
            :class="[`text-${textAlign}`, hasSuffix ? 'pr-0' : '']"
            :tabindex="tabindex"
            :placeholder="placeholder"
            :value="formatValue"
            @input="onInput()"
            :disabled="isDisabled"
            @blur="$emit('blur')"
            @keydown="onKeyDown"
        />
        <div class="suffix" v-if="hasSuffix">
            <div class="suffix__btn icon--increase" @click="increase()"></div>
            <div class="suffix__btn icon--decrease" @click="decrease()"></div>
        </div>
    </div>
</template>
<script>
export default {
    name: "MISAInput",
    props: {
        tabindex: {
            type: Number,
            required: false,
            default: -1,
        },
        placeholder: {
            type: String,
            required: false,
            default: "",
        },
        modelValue: {
            // 2 way binding with v-model
            type: String,
            required: true,
        },
        prefixIcon: {
            type: String,
            required: false,
            default: "",
        },
        isDisabled: {
            type: Boolean,
            required: false,
            default: false,
        },
        textAlign: {
            type: String,
            required: false,
            default: "left",
        },
        formatCurrency: {
            type: Boolean,
            required: false,
            default: false,
        },
        isNumberOnly: {
            type: Boolean,
            required: false,
            default: false,
        },
        isError: {
            type: Boolean,
            required: false,
            default: false,
        },
        hasSuffix: {
            type: Boolean,
            required: false,
            default: false,
        },
        max: {
            type: Number,
            required: false,
            default: 99999999999999,
        },
        min: {
            type: Number,
            required: false,
            default: 0,
        },
    },
    watch: {},
    methods: {
        /**
         * Handle Onkey UP and Down
         * Author: NDThien 27/07/2023
         */
        onKeyDown() {
            // Chỉ thực hiện khi có suffix là biểu tượng tăng/giảm đơn vị của input number
            if (this.hasSuffix) {
                const keyCode = event.keyCode;
                switch (keyCode) {
                    case this.$_MISAEnum.KeyCode.Down:
                        this.decrease();
                        break;
                    case this.$_MISAEnum.KeyCode.Up:
                        this.increase();
                        break;
                }
            }
        },
        /**
         * Tăng giá trị của input number nên 1 đơn vị
         * Author: NDThien 12/7/2023
         */
        increase() {
            let number = this.formatValue;
            if (this.formatCurrency) {
                number = number.replaceAll(".", "");
            }
            this.formatValue = ++number;
        },
        /**
         * Giảm giá trị của input number nên 1 đơn vị
         * Author: NDThien 12/7/2023
         */
        decrease() {
            let number = this.formatValue;
            if (this.formatCurrency) {
                number = number.replaceAll(".", "");
            }
            this.formatValue = --number;
        },
        /**
         * Xử lý input đầu vào
         * Author: NDThien 16/07/2023
         */
        onInput() {
            let newVal = event.target.value;
            let originalLen = event.target.value.length; // Lấy giá trị length hiện tại
            let indexCursor = event.target.selectionStart; // Lấy giá trị cursor hiện tại
            // Trường hợp format tiền
            if (this.formatCurrency) {
                newVal = newVal.replaceAll(/[^0-9]/g, "");
                newVal = this.$_MISAFunctions.convertNumberToCurrency(newVal);
                event.target.value = newVal;
            }
            // Trường hợp chỉ nhận số
            if (this.isNumberOnly) {
                newVal = newVal.replaceAll(/[^0-9]/g, "");
                event.target.value = newVal;
            }
            // Cập nhật model value binding 2 chiều
            this.formatValue = newVal;

            // Tính toán vị trí con trỏ chuột sau khi format (trong trường hợp chèn kí tự vào giữa input)
            let updatedLen = newVal.length; // Lấy giá trị length sau khi format
            indexCursor = updatedLen - originalLen + indexCursor; // Tính toán vị trí hiện tại của con trỏ chuột
            this.$refs["misaInput"].setSelectionRange(indexCursor, indexCursor); // Set con trỏ chuột về vị trí cũ vì sau khi format con trỏ chuột auto về cuối
        },
    },
    mounted() {},
    computed: {
        /**
         * Format value đầu vào (tiền, ...) từ v-model (modelValue)
         * 100000 -> 100.000
         * 100.000 -> 100.000
         * Author: NDThien 16/07/2023
         */
        formatValue: {
            get() {
                let val = this.modelValue;
                if (this.formatCurrency) {
                    val = val?.toString().replaceAll(".", "");

                    // Kiểm tra max min của input
                    if (val > this.max) {
                        val = this.max;
                    } else if (val < this.min) {
                        val = this.min;
                    }

                    val = this.$_MISAFunctions.convertNumberToCurrency(val);
                }
                return val;
            },
            set(val) {
                // Cập nhật model value binding 2 chiều
                this.$emit("update:modelValue", val);
            },
        },
    },
};
</script>
<style scoped>
@import url(../../css/base/input.css);
@import url(../../css/base/input-number.css);
</style>

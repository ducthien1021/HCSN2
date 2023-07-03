<template>
  <div class="base-input" :class="inputClass">
    <div class="label">
      <label :for="name">{{ label }}</label>
      <div v-if="required" class="required">*</div>
    </div>
    <div class="input">
      <input ref="myInput" :type="type" :name="name" :required="required" :value="inputValue" :disabled="disabled"
        :min="min" :max="max" :class="{ 'error': error }" v-model="inputValue" @input="onInput" @blur="validateInput" />
    </div>
    <div v-if="error" class="error-message"> {{ error }}</div>
  </div>
</template>
  
<script>
export default {
  name: "BaseInput",

  mounted() {
    /**
     * @description: Focus vào input khi được khởi tạo
     * Author: PQNAM (29/06/2023)
     */
    if (this.isFocus) {
      this.$refs.myInput.focus();
    }
    if (this.disabled) {
      this.inputValue = this.value;
    }
  },

  props: {
    /**
     * @description: Loại input
     * Author: PQNAM (29/06/2023)
     */
    type: {
      type: String,
      default: "text"
    },
    /**
     * @description: Modify để căn lề cho input (số, chữ)
     */
    typeInput: {
      type: String,
      default: "text"
    },
    /**
     * @description: Tên của input
     *  Author: PQNAM (29/06/2023)
     */
    name: {
      type: String,
      required: true
    },
    /**
     * @description: Nhãn của input
     * Author: PQNAM (29/06/2023)
     */

    label: {
      type: String,
      required: true
    },
    /**
     * @description: Bắt buộc nhập hay không
     * Author: PQNAM (29/06/2023)
     */
    required: {
      type: Boolean,
      default: false
    },
    /**
     * @description: Không cho phép nhập hay không
     * Author: PQNAM (29/06/2023)
     */
    disabled: {
      type: Boolean,
      default: false
    },
    /**
     * @description: Giá trị nhỏ nhất và lớn nhất của input
     */
    min: {
      type: Number,
      default: null
    },
    /**
     * @description: Giá trị nhỏ nhất và lớn nhất của input
     */
    max: {
      type: Number,
      default: null
    },
    /**
     * @description: Giá trị của input
     * Author: PQNAM (29/06/2023)
     */

    value: {
      type: String,
      default: ""
    },

    /**
     * @description: Hàm validate của input
     */
    validate: {
      type: Function,
      default: null
    },
    /**
     * @description: Focus vào input khi được khởi tạo
     */
    isFocus: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      inputValue: "", // Giá trị của input
      error: "" // Lỗi của input
    };
  },

  computed: {

    /**
     * @description: Lấy class cho input
     * Author: PQNAM (29/06/2023)
     */
    inputClass() {
      if (this.typeInput === "number") {
        return "base-input--number";
      }
      return "base-input--text";
    },

    /**
     * 
     * @description: Lấy giá trị hiển thị của input
     * Author: PQNAM (29/06/2023)
     */
    displayValue: {
      get() {
        return this.inputValue !== null ? this.inputValue : this.value;
      },
      set(newValue) {
        this.inputValue = newValue;
        this.$emit("input-value", newValue);
      }
    }

  },
  methods: {
    /**
     * @description: Xử lý sự kiện input
     * Author: PQNAM (29/06/2023)
     */
    onInput() {
      this.$emit("input-value", event.target.value);
      this.inputValue = event.target.value;
      this.validateInput();
    },

    /**
     * @description: Validate input
     * Author: PQNAM (29/06/2023)
     */
    validateInput() {
      if (this.validate) {
        this.error = this.validate(this.inputValue);
      }
    },
  }

};
</script>
  
<style>
.base-input {
  display: flex;
  position: relative;
  flex-direction: column;
}

.base-input input {
  width: 100%;
  height: 36px;
  border-radius: 4px;
  border: 1px solid #e0e0e0;
  font-size: 14px;
  box-sizing: border-box;
  padding-left: 14px;

}

.base-input input:focus {
  outline: none;
  border: 1px solid #0078d4;
}

.base-input--text input {
  text-align: left;

}

.base-input--number input {
  text-align: right;
  padding-right: 16px;
}

.base-input .error-message {
  color: red;
  font-size: 12px;
  margin-top: 6px;
}

.base-input input.error {
  border-color: red;
}

input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: inner-spin-button;
  display: none;
  margin-left: 10px;
}

input[type="number"]:focus::-webkit-inner-spin-button {
  -webkit-appearance: none;
  display: block;
  margin-left: 10px;
  width: 8px;
  height: 16px;
  cursor: pointer;
  background: url('../../../assets/icon/qlts-icon.svg') no-repeat -204px -332px;
}


input[type="date"]::-webkit-calendar-picker-indicator {
  margin-right: 10px;
  /* Thay đổi giá trị margin-left tùy ý */
  background: url('../../../assets/icon/qlts-icon.svg') no-repeat -287px -67px;
  width: 18px;
  height: 18px;
}

.label {
  display: flex;
  align-items: center;
  font-size: 13px;
  margin-bottom: 8px;
}

.required {
  color: red;
  margin-left: 4px;
  text-align: center;
}
</style>
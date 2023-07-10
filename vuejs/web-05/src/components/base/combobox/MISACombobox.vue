<template>
    <div class="default-combobox" ref="combobox">
        <span :class="iconClass"></span>
        <input :class="customClass" :tabindex="tab" :type="customType" id="customId" :placeholder="customPlaceholder"
            v-model="textInput" @focus="onShowCbb" @keydown="handleKeyDown" />
        <div class="up-down">
            <div class="down">
                <div @click="onShowCbb" class="icon-down-bold"></div>
            </div>
        </div>
        <div v-show="showCbb" class="combobox__data">
            <a class="combobox__data--item" :class="{ 'combobox__data--item-selected': item == itemSelected }"
                v-for="(item, index) in dataFilter" :key="index" @click="onSelectItem(item)">
                {{ item[propText] }}
            </a>
        </div>



    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "MISACombobox",
    props: {
        customType: {
            type: String
        },
        iconClass: {
            type: String
        },
        customId: {
            type: String
        },
        customClass: {
            type: String
        },
        customPlaceholder: {
            type: String
        },
        api: {
            type: String
        },
        propText: {
            type: String,
        },
        propValue: {
            type: String,
        },
        tab: {
            type: String
        },
        modelValue: {}

    },
    created() {
        this.loadData();
    },

    mounted() {
        document.addEventListener("click", this.handleClickOutside);
    },

    beforeUnmount() {
        document.removeEventListener("click", this.handleClickOutside);
    },
    watch: {
        textInput: function (newValue) {

            let dataFilter = this.dataCbb.filter(i => i[this.propText].includes(newValue.toUpperCase()))
            if (dataFilter != null) {
                this.dataFilter = dataFilter
            }
        }
    },

    methods: {
        /**
       * @description: lấy dữ liệu về combobox
       * @author: DDTung (03/07/2023)
       */
        loadData() {
            if (this.api) {
                axios.get(this.api)
                    .then(res => {
                        this.dataCbb = res.data;
                        this.dataFilter = [...this.dataCbb]
                        let indexSelected = this.dataFilter.findIndex(i => i[this.propValue] === this.modelValue);
                        this.itemSelected = this.dataFilter[indexSelected];
                        this.textInput = this.itemSelected[this.propText]
                    })
                    .catch(err => console.log(err))
            }
        },
        /**
       * @description: ẩn hiện cbb
       * @author: DDTung (03/07/2023)
       */
        onShowCbb() {
            this.showCbb = !this.showCbb;
        },
        /**
       * @description: xử lý sự kiện khi chọn vào 1 item cbb
       * @author: DDTung (03/07/2023)
       */
        onSelectItem(item) {
            this.itemSelected = item
            this.textInput = item[this.propText]
            this.$emit("update:modelValue", item[this.propValue])
            this.showCbb = false;
        },

        /**
              * @description: xử lý sự kiện khi click ra ngoài cbbb
              * @author: DDTung (03/07/2023)
              */
        handleClickOutside() {
            if (!this.$refs["combobox"].contains(event.target)) {
                this.showCbb = false;
            }
        },
        handleKeyDown(event) {
            if (event.key === 'Tab') {
                this.showCbb = false;
            }
        }
    },
    data() {
        return {
            showCbb: false,
            dataCbb: [],
            dataFilter: [],
            itemSelected: {},
            textInput: "",

        }
    }
}
</script>

<style scoped>
.default-combobox {
    position: relative
}

.default-combobox input {
    margin-right: 11px;
}

.default-combobox input::placeholder {
    font-size: 13px;
    font-weight: 400;
}

.combobox-input {
    background-color: #fff;
    border-radius: 2.5px;
    border: 1px solid #afafaf;
    width: 60px;
    height: 25px;
    overflow: hidden;
    padding: 0 15px;
}

.icon-filter {
    background: var(--icon-url) no-repeat -240px -65px;
}

.icon-down-bold {
    background: var(--icon-url) no-repeat -64px -328px;
    position: absolute;
    width: 24px;
    height: 24px;
    top: 50%;
    transform: translateY(-50%);
    right: 8px !important
}

.icon-down-bold:hover {
    cursor: pointer;
}

.combobox__data {
    position: absolute;
    display: flex;
    flex-direction: column;
    z-index: 11111;
    width: 100%;
    top: calc(100% + 2px);
    box-shadow: 0 0 5px #000;
    background-color: #fff;
    border: 1px solid #e6e6e6;
    border-radius: 4px;
    max-height: 200px;
    overflow-y: auto;
}

.combobox__data--item {
    color: black;
    padding: 12px;
}

.combobox__data--item:hover {
    background-color: #3fc5e7;
    cursor: pointer;
}

.combobox__data--item-selected {
    background-color: #22b1d5;

}




.combobox__data::-webkit-scrollbar {
    width: 7px;
    height: 7px;
}



.combobox__data::-webkit-scrollbar-track {
    border-radius: 10px;
    background: #d1dae9;
}



.combobox__data::-webkit-scrollbar-thumb {
    background: #abb6c8;
    border-radius: 10px;
}



.combobox__data::-webkit-scrollbar-thumb:hover {
    background: #abb6c8;
}
</style>
<template>
    <div class="overlay" v-if="isOpen">
        <div class="form-wrapper">
            <div class="form-header">
                <h3>Thêm tài sản</h3>
                <button class="btn-close" @click="closeForm">
                    <MISAIcon class="icon" :pX="this.$_icons.close.pX" :pY="this.$_icons.close.pY"
                        :width="this.$_icons.close.width" :height="this.$_icons.close.height"
                        :scale="this.$_icons.close.scale" />
                </button>
            </div>
            <div class="form-body">
                <form class="form">
                    <div class="form-group" style="grid-row-start: 1; grid-column-start: 1;">
                        <MISABaseInput ref="firstInput" label="Mã tài sản" style="width: 100%; height: 36px;"
                            required="true" v-model="assetName" @input-value="handleInput" :validate="validateAssetName"
                            isFocus="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 1; grid-column: 2/ span 2;">
                        <MISABaseInput label="Tên tài sản" style="width: 100%; height: 36px;" required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 2; grid-column-start: 1;">
                        <div class="label">
                            <label>Mã bộ phận sử dụng</label>
                            <div class="required">*</div>
                        </div>
                        <MISASelectInput icons="false" placeholder="Chọn mã bộ phận sử dụng"
                            style="width: 100%; height: 36px;" />
                    </div>
                    <div class="form-group" style="grid-row-start: 2; grid-column: 2/ span 2;">
                        <MISABaseInput label="Tên bộ phận sử dụng" value="Phòng hành chính tổng hợp" disabled="true"
                            style="width: 100%; height: 36px;" />
                    </div>
                    <div class="form-group" style="grid-row-start: 3; grid-column-start: 1;">
                        <div class="label">
                            <label>Mã loại tài sản</label>
                            <div class="required">*</div>
                        </div>
                        <MISASelectInput icons="false" placeholder="Chọn loại tài sản" style="width: 100%; height: 36px;" />
                    </div>
                    <div class="form-group" style="grid-row-start: 3; grid-column: 2/ span 2;">
                        <MISABaseInput label="Tên loại tài sản" value="Máy tính xách tay" disabled="true"
                            style="width: 100%; height: 36px;" />
                    </div>
                    <div class="form-group" style="grid-row-start: 4; grid-column-start: 1;">
                        <MISABaseInput label="Số lượng" type-input="number" type="number" :min="1" :max="10"
                            style="width: 100%; height: 36px;" required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 4; grid-column-start: 2;">
                        <MISABaseInput label="Nguyên giá" type-input="number" type="text" style="width: 100%; height: 36px;"
                            required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 4; grid-column-start: 3;">
                        <MISABaseInput label="Số năm sử dụng" type-input="number" type="text"
                            style="width: 100%; height: 36px;" required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 5; grid-column-start: 1;">
                        <MISABaseInput label="Tỷ lệ hao mòn (%)" type-input="number" type="number" :min="1" :max="10"
                            style="width: 100%; height: 36px;" required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 5; grid-column-start: 2;">
                        <MISABaseInput label="Giá trị hao mòn năm" type-input="number" type="text"
                            style="width: 100%; height: 36px;" required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 5; grid-column-start: 3;">
                        <MISABaseInput label="Năm theo dõi" value=2021 type-input="number" type="text" disabled="true"
                            style="width: 100%; height: 36px;" />
                    </div>
                    <div class="form-group" style="grid-row-start: 6; grid-column-start: 1;">
                        <MISABaseInput label="Ngày mua" type="date" value="2012-07-07" style="width: 100%; height: 36px;"
                            required="true" />
                    </div>
                    <div class="form-group" style="grid-row-start: 6; grid-column-start: 2;">
                        <MISABaseInput label="Ngày bắt đầu sử dụng" type="date" style="width: 100%; height: 36px;"
                            required="true" />
                    </div>


                </form>
            </div>
            <div class="form-footer">
                <MISANormalButton class="btn btn-cancel">Hủy</MISANormalButton>
                <MISANormalButton class="btn btn-save">Lưu</MISANormalButton>
            </div>
        </div>
    </div>
</template>
<script>
import MISABaseInput from '@/components/base/input/MISABaseInput.vue';
import MISASelectInput from '@/components/base/input/MISASelectInput.vue';
import MISANormalButton from '@/components/base/button/MISANormalButton.vue';
export default {
    name: 'MISAAddPropertyForm',
    data() {
        return {
            assetName: "", // Tên tài sản
        }
    },
    props: {
        /**
         * Trạng thái mở form
         * Author: PQNAM (29/06/2023)
         */
        isOpen: {
            type: Boolean,
            default: false
        }
    },
    components: {
        MISABaseInput,
        MISASelectInput,
        MISANormalButton
    },
    methods: {
        /**
         * Đóng form
         * Author: PQNAM (29/06/2023)
         */
        closeForm() {
            this.$emit('close');
        },

        /**
         * 
         * @param {*} value 
         * 
         * Xử lý sự kiện nhập tên tài sản
         * Author: PQNAM (29/06/2023)
         */
        handleInput(value) {
            this.assetName = value;
        },

        /**
         * 
         * @param {*} assetName
         * Author: PQNAM (29/06/2023)
         */
        validateAssetName(assetName) {
            if (assetName.length == 0) {
                return 'Vui lòng nhập tên';
            } else if (assetName.length < 5) {
                return 'Tên phải có ít nhất 5 ký tự';
            } else {
                return '';
            }
        },
    },
}
</script>

<style scoped>
.overlay {
    background-color: #968d8dac;
    width: 100%;
    height: 100%;
    position: fixed;
    z-index: 999;
    top: 0;
    left: 0;
}

.form-wrapper {
    display: flex;
    flex-direction: column;
    width: 1000px;
    height: 600px;
    padding: 20px 16px 0 16px;
    box-sizing: border-box;
    background-color: #fff;
    border-radius: 4px;
    box-shadow: 0px 4px 16px rgba(0, 0, 0, 0.1);
    position: relative;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}

.form-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 18px;
    margin-bottom: 20px;
}

.btn-close {
    width: 18px;
    height: 18px;
    background-color: #fbadad;
    background: url(../../assets/icon/qlts-icon.svg) no-repeat -375px -287px;
    border: none;
    outline: none;
}

.form-body {
    flex: 1;
    width: 100%;
}

.form-footer {
    height: 52px;
    width: calc(100% + 16px);
    border-top: 1px solid #ebeef5;
    display: flex;
    justify-content: flex-end;
    align-items: center;
    background-color: #ebeef5;
    column-gap: 10px;
    margin-left: -16px;
    margin-right: -16px;
    border-radius: 0px 0px 4px 4px;
    padding-right: 16px;
}

.form {
    display: grid;
    width: 100%;
    height: 100%;
    grid-template-columns: repeat(3, 1fr);
    grid-template-rows: repeat(6, 1fr);
    column-gap: 16px;
}

.form-group {
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 100%;
    box-sizing: border-box;
}



.label {
    display: flex;
    align-items: center;
}

.required {
    color: red;
    margin-left: 4px;
    text-align: center;
}

.input-right {
    text-align: right;
}

.label {
    font-size: 13px;
    margin-bottom: 8px;
}

.number-input input {
    text-align: right;

}

.btn {
    width: 106px;
    height: 36px;
    border-radius: 2.5px;
    border: none;
    outline: none;
    cursor: pointer;
    font-size: 13px;
    font-weight: 500;
    line-height: 16px;

}

.btn.btn-cancel {
    background-color: #fff;
    color: #000;
}

.btn.btn-save {
    background-color: var(--basic-color);
    color: #fff;
}

.btn.btn-save:hover {
    background-color: var(--btn-hover-color);
}

.btn.btn-cancel:hover {
    background-color: #ebeef5;
}

.btn.btn-save:active {
    background-color: var(--btn-active-color);
}

.btn.btn-cancel:active {
    background-color: #dbdee6;
}
</style>
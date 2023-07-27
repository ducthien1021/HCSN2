<template lang="">
    <div class="content">
        <div class="content__top">
            <div class="content__left">
                <div class="input-icon flex-1">
                    <div
                        class="input-icon__icon input-icon__icon--search"
                    ></div>
                    <input
                        type="text"
                        class="input-icon__inp"
                        placeholder="Tìm kiếm tài sản"
                    />
                </div>
                <MISACombobox
                    class="flex-1"
                    :iconFilter="true"
                    placeholder="Loại tài sản"
                    :dataSource="[]"
                    :dataFields="[]"
                />
                <MISACombobox
                    class="flex-1"
                    :iconFilter="true"
                    placeholder="Bộ phận sử dụng"
                    :dataSource="[]"
                    :dataFields="[]"
                />
            </div>
            <div class="content__right">
                <MISAButton
                    type="main"
                    icon="add"
                    text="Thêm tài sản"
                    @click="openAssetDetail()"
                />
                <MISAButton type="btn-icon" icon="excel" />
                <MISAButton type="btn-icon" icon="delete" />
            </div>
        </div>

        <AssetDataTables />

        <AssetDetail
            v-if="isShowAssetDetail"
            @closeAssetDetail="closeAssetDetail()"
        />

        <MISADialog v-show="false" />
    </div>
</template>
<script>
import AssetDataTables from "./AssetDataTables.vue";
import AssetDetail from "./AssetDetail.vue";
import MISADialog from "../../base/MISADialog.vue";

export default {
    name: "AssetPage",
    components: {
        AssetDataTables,
        AssetDetail,
        MISADialog,
    },
    data() {
        return {
            isShowAssetDetail: false,
        };
    },
    methods: {
        /**
         * Open Asset Detail
         * Author: NDThien 25/6/2023
         */
        openAssetDetail() {
            this.isShowAssetDetail = true;
        },
        /**
         * Close Asset Detail
         * Author: NDThien 25/6/2023
         */
        closeAssetDetail() {
            this.isShowAssetDetail = false;
        },
    },
};
</script>
<style scoped>
@import url(../../../css/layout/content.css);
</style>

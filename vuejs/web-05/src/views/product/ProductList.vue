<template>
  <div class="main-header d-flex justify-content-between">
    <div class="l-main d-flex align-items-center">
      <MISAInput iconClass="input-icon icon-search" customClass="default-input" customPlaceholder="Tìm kiếm tài sản">
      </MISAInput>
      <MISACombobox iconClass="input-icon icon-filter" customClass="default-input" customPlaceholder="Loại tài sản">
      </MISACombobox>
      <MISACombobox iconClass="input-icon icon-filter" customClass="default-input" customPlaceholder="Bộ phận sử dụng">
      </MISACombobox>

    </div>
    <div class="r-main d-flex align-items-center">
      <MISAButton customId="btn-add" customClass="btn--primary d-flex align-items-center" iconClass="btn--primary-icon"
        text="Thêm tài sản" @click="handleForm">
      </MISAButton>
      <MISAButton iconClass="btn--option"></MISAButton>
      <MISAButton iconClass="btn--delete" @click="deleteSelected"></MISAButton>
    </div>
  </div>

  <MISATable :products="products" :totalQuantity="totalQuantity" :totalPrice="totalPrice"
    :totalDepreciation="totalDepreciation" :totalResidual="totalResidual" :onUpdate="onUpdate">
  </MISATable>
  <MISALoading v-if="isLoading"></MISALoading>


  <MISAForm v-if="isFormVisible" :isFormVisible="isFormVisible" @close-form="closeForm" :productEdit="productForUpdate">
  </MISAForm>
</template>

<script>
import axios from 'axios';

export default {
  name: "ProductList",
  /**
   * @author: DDTung (27/06/2023)
   * @description: Lấy api sản phẩm 
   */
  async created() {
    try {
      this.isLoading = true;
      const response = await axios.get("https://64798739a455e257fa6347c2.mockapi.io/users");
      await new Promise((resolve) => setTimeout(resolve, 3000));
      this.products = response.data;
      this.isLoading = false;
    } catch (error) {
      console.error(error);
    }
  },

  data() {
    return {
      products: [],
      isFormVisible: false,
      isLoading: false,
      productForUpdate: {},
      productForAdd: {
        ProductsCode: "TS00001",
        ProductsName: "",
        ProductsType: "",
        ProductsDepartment: "",
        ProductsQuantity: 1,
        ProductsPrice: 0,
        ProductsDepreciation: 1,
        ProductsResidual: 0,
        ProductsChecked: false,
        DepartmentCode: "",
      }
    };
  },

  computed: {
    /**
     * @returns: Tính tổng số lượng
     * @author: DDTung (27/06/2023)
     */
    totalQuantity() {
      return this.products.reduce((total, product) => total + product.ProductsQuantity, 0);
    },
    /**
    * @returns: Tính tổng nguyên giá
    * @author: DDTung (27/06/2023)
    */
    totalPrice() {
      return this.products.reduce((total, product) => total + Number(product.ProductsPrice), 0);
    },
    /**
    * @returns: Tính tổng khấu hao
    * @author: DDTung (27/06/2023)
    */
    totalDepreciation() {
      return this.products.reduce((total, product) => total + Number(product.ProductsDepreciation), 0);
    },
    /**
    * @returns: Tính tổng số tiền còn lại
    * @author: DDTung (27/06/2023)
    */
    totalResidual() {
      return this.products.reduce((total, product) => total + Number(product.ProductsResidual), 0);
    },
  },
  methods: {
    handleForm() {
      this.productForUpdate = this.productForAdd
      this.isFormVisible = true;
    },
    closeForm() {
      this.productForUpdate = this.productForAdd;
      this.isFormVisible = false;
    },
    onUpdate(product) {
      this.isFormVisible = true;
      this.productForUpdate = product
    },
    btnAddOnClick() {
      this.productForUpdate = {};
      this.isFormVisible = true;
    },
    async deleteSelected() {
      const selectedProducts = this.products.filter(product => product.ProductsChecked);
      for (const product of selectedProducts) {
        try {
          await axios.delete(`https://64798739a455e257fa6347c2.mockapi.io/users/${product.ProductsId}`);
          this.products = this.products.filter(p => p.ProductsId !== product.ProductsId);
        } catch (error) {
          console.error(error);
        }
      }
    }

  }
}


</script>

<style></style>
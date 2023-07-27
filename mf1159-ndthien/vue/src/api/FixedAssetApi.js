import AxiosClient from "./AxiosClient"

const controller = "/v1/fixedAssets";
const fixedAssetApi = {
    /**
     * Get all fixed asset
     * @returns List Fixed Asset
     * Author: NDThien 17/07/2023
     */
    getAll() {
        return AxiosClient.get(`${controller}`);
    },
    /**
     * Get fixed asset by id
     * @param {*} id Fixed asset id
     * @returns 
     */
    getById(id) {
        return AxiosClient.get(`${controller}/${id}`)
    },
    /**
     * Insert fixed asset
     * @param {*} data Fixed asset object insert
     * @returns Number of record changed
     * Author: NDThien 17/07/2023
     */
    insert(data) {
        return AxiosClient.post(`${controller}`, data);
    },
    /**
     * Update fixed asset
     * @param {*} id Fixed Asset Id to update
     * @param {*} data Fixed asset object update
     * @returns Number of record changed
     * Author: NDThien 17/07/2023
     */
    update(id, data) {
        return AxiosClient.put(`${controller}/${id}`, data);
    },
    /**
     * Delelte fixed asset
     * @param {*} id Fixed Asset Id to delete
     * @returns Number of record changed
     * Author: NDThien 17/07/2023
     */
    delete(id) {
        return AxiosClient.delete(`${controller}/${id}`);
    },
    /**
     * Get new fixed asset code
     * @returns New fixed asset code
     * Author: NDThien 24/07/2023
     */
    getNewCode() {
        return AxiosClient.get(`${controller}/new-code`);
    },
    /**
     * Get paging filter list fixed asset
     * @returns List fixed asset
     * Author: NDThien 24/07/2023
     */
    pagingFilter(pagingFilter) {
        return AxiosClient.post(`${controller}/paging-filter`, pagingFilter);
    }
};

export default fixedAssetApi;
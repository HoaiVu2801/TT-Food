import axiosClient from "./axiosClient";

export const unitApi = {
    getAll() {
        const url = '/Units';
        var result = axiosClient.get(url);
        return result;
    },
    insertUnit(values) {
        const url = `/Units/create`;
        var result = axiosClient.post(url, values);
        return result;
    },
    getUnitById(id) {
        const url = `/Units/${id}`;
        var result = axiosClient.get(url);
        return result;
    },

    updateUnit(values) {
        const url = `/Units/update/${values.id}`;
        var result = axiosClient.put(url, values);
        return result;
    },
    deleteUnit(id) {
        const url = `/Units/delete/${id}`;
        var result = axiosClient.delete(url);
        return result;
    },
}
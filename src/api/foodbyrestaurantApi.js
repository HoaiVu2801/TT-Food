import axiosClient from "./axiosClient";

export const foodbyrestaurantApi = {
    getAll() {
        const url = '/FoodByRestaurants';
        var result = axiosClient.get(url);
        return result;
    },
    insertFoodByRestaurant(values) {
        const url = `/FoodByRestaurants/create`;
        var result = axiosClient.post(url, values);
        return result;
    },
    getFoodByRestaurantById(id) {
        const url = `/FoodByRestaurants/${id}`;
        var result = axiosClient.get(url);
        return result;
    },

    updateFoodByRestaurant(values) {
        const url = `/FoodByRestaurants/update/${values.id}`;
        var result = axiosClient.put(url, values);
        return result;
    },
    deleteFoodByRestaurant(id) {
        const url = `/FoodByRestaurants/delete/${id}`;
        var result = axiosClient.delete(url);
        return result;
    },
}
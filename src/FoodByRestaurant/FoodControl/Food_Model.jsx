import { foodbyrestaurantApi } from '@/api/foodbyrestaurantApi';
import { ConfigProvider, Form, Modal } from 'antd';
import React, { useEffect, useState } from 'react';
import Food from './Food';
import en_US from 'antd/locale/en_US';

function Food_Model(props) {
    const { onClose, onSuccess, onError, isAdd, food } = props;
    const onSubmit = async (data) => {
        try {
            if (isAdd) {
                const t = data.foodName;
                const r = t.split(", ", );
                r.map(async (item) => {
                    data.foodName = item;
                    await foodbyrestaurantApi.insertFoodByRestaurant(data);
                    onSuccess();
                });
            }
            else {
                await foodbyrestaurantApi.updateFoodByRestaurant(data); 
                onSuccess();
            }
        }
        catch {
            onError();
        }
    }
    const [form] = Form.useForm();
    useEffect(() => {
        form.setFieldsValue(food);
    }, [food])

    const close = () => {
        onClose();
        form.resetFields();
    }
    return (
        <>
            <Modal
                title="Thêm Đơn Vị"
                open={true}
                onOk={form.submit}
                onCancel={close}
            >
                <Food form={form} onSubmit={onSubmit} isAdd={isAdd} food={food} />
            </Modal>
        </>
    );
}

export default Food_Model;
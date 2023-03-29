import { unitApi } from '@/api/unitApi';
import { Form, Modal } from 'antd';
import React, { useEffect } from 'react';
import Unit from './Unit';

function Unit_Model(props) {
    const { onClose, onSuccess, onError, isAdd, unit } = props;
    const onSubmit = async (data) => {
        try {
            if (isAdd){
                const res = await unitApi.insertUnit(data);
            }
            else {
                const res = await unitApi.updateUnit(data);
            }
            onSuccess();
        }
        catch {
            onError();
        }
    }
    const [form] = Form.useForm();
    useEffect(() => {
        form.setFieldsValue(unit);
    }, [unit])

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
                <Unit form={form} onSubmit={onSubmit} isAdd={isAdd} />
            </Modal>
        </>
    );
}

export default Unit_Model;
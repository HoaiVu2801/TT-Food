import React, { useState, useEffect } from 'react';
import { Form, Input, InputNumber, Select, DatePicker, ConfigProvider } from 'antd';
import TextArea from 'antd/es/input/TextArea';
import { unitApi } from '@/api/unitApi';
import moment from 'moment';
import en_US from 'antd/locale/en_US';
function index(props) {
    const { form, onSubmit, food } = props;
    const layout = {
        labelCol: {
            span: 8,
        },
        wrapperCol: {
            span: 16,
        },
    };
    const validateMessages = {
        required: '${label} is required!',
    };
    const onUpdate = async (data) => {
        onSubmit(data);
    };
    const [units, setUnits] = useState([]);
    const getAllUnit = async () => {
        const res = await unitApi.getAll();
        const a = await res.data.map(x => {
            return {
                label: x.unitName,
                value: x.unitID,
            }
        });
        setUnits(a);
    }
    useEffect(() => {
        getAllUnit()
    }, []);
    return (
        <>
            <Form
                {...layout}
                name="nest-messages"
                onFinish={onUpdate}
                form={form}
                style={{
                    maxWidth: 600,
                }}
                validateMessages={validateMessages}
                initialValues={{ mode: 1, foodID: "", unitID: "Đơn Vị", type: "Món Mặn" }}
            >
                <Form.Item name="foodID" hidden>
                    <Input hidden />
                </Form.Item>
                <Form.Item
                    name="foodName"
                    label="Name"
                    rules={[
                        {
                            required: true,
                        },
                    ]}
                >
                    <TextArea rows={3} />
                </Form.Item>
                <Form.Item
                    name="unitID"
                    label="UnitName"
                    rules={[
                        {
                            required: true,
                            message: "Please select a unit",
                        }
                    ]}
                >
                    <Select
                        allowClear
                        options={units}
                    />
                </Form.Item>
                
                <Form.Item
                     name='createdDate'
                     label='Created Date'
                    >
                    <DatePicker style={{ width: '100%' }}  locale={{locale: 'vn_VN'}}
                    />
                    </Form.Item>
                <Form.Item
                    name="type"
                    label="Type"
                    rules={[
                        {
                            required: true,
                        }
                    ]}
                >
                    <Select>
                        <Select.Option value="Món Mặn">Món Mặn</Select.Option>
                        <Select.Option value="Món Rau">Món Rau</Select.Option>
                    </Select>
                </Form.Item>
                <Form.Item name="mode" hidden>
                    <InputNumber hidden />
                </Form.Item>
                <Form.Item
                    wrapperCol={{
                        ...layout.wrapperCol,
                        offset: 8,
                    }}
                >
                </Form.Item>
            </Form>
        </>
    );
}

export default index;
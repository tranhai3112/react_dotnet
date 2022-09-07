import Devider from './Devider'
import useRQGlobalState from '../../hooks/customUseQuery'
import {key} from '../../hooks/customUseQuery'
import { useCallback } from 'react'
import { useAddBook } from '../../api/Book/bookHooks'
import { useState } from 'react'

const Modal = () => {
    const [visible, setVisible] = useRQGlobalState(key.MODAL_ADD_BOOK, false)
    const [formData, setFormData] = useState({
        name: '',
        descripion:'',
        price:0
    })
    const mutate = useAddBook()
    const closeModal = useCallback(() => {
        setVisible(false)
    },[])
    const submitForm = () => {
        mutate.mutate(formData)
        closeModal()
    }
    const onChangeFormdata = (e) => {
        const id = e.target.id
        const value = e.target.value
        setFormData(prevState => {
            return {...prevState,[id]: value}
        })
    }
  return (
    <>
    {visible && (
        <>
        <div className='modal'>
            <div className='modal-wrapper'>
                <div className='modal-header'>
                    Add book
                </div>
                <Devider/>
                <div className='modal-content'>
                    <div className='form-input'>
                        <input type="text" placeholder='name' name='name' id='name' onChange={onChangeFormdata}/>
                    </div>
                    <div className='form-input'>
                        <input type="text" placeholder='description' name='descripion' id='descripion' onChange={onChangeFormdata}/>
                    </div>
                    <div className='form-input'>
                        <input type="number" placeholder='price' name='price' id='price' min={0} onChange={onChangeFormdata}/>
                    </div>
                </div>
                <div className='modal-btn'>
                    <div className='btn btn-info' onClick={submitForm}>Confirm</div>
                    <div className='btn' onClick={closeModal}>Cancel</div>
                </div>
            </div>
            <div className='modal-close' onClick={closeModal}>x</div>
        </div>
        <div className='modal-back-drop' onClick={closeModal}/>
        </>
    )}
    
    </>
    
  )
}

export default Modal

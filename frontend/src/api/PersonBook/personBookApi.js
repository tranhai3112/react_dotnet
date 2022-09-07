import axiosClient from "../apiService";

const prefix = 'api/PersonBook'

export async function addToMyBook(params) {
    try {
        const response = await axiosClient.post(prefix, params)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}

export async function getAll() {
    try {
        const response = await axiosClient.get(prefix)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}

export async function removePersonBook(id) {
    try {
        const url = `${prefix}/${id}`
        const response = await axiosClient.delete(url, id)
        return response
    } catch (error) {
        console.error(error)
        return null
    }
}
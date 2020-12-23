import { AppState } from '../AppState'
import { api } from './AxiosService'

class ContractorService {
  async getAll() {
    try {
      const res = await api.get('api/contractors')
      AppState.contractors = res.data
    } catch (err) {
      console.log(err)
    }
  }
}

export const contService = new ContractorService()

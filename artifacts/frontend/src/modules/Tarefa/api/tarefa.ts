/**
 * arquivo de api trata da parte de requisicao e suas configuracoes
 */
import adminApi, { adminApiConfig } from '@/api/admin'
import type {
  Tarefa,
  TarefaCreateReq,
  TarefaListRes,
  TarefaCreateRes,
  TarefaGetRes,
  TarefaUpdateRes,
  TarefaDeleteRes,
} from '../types/tarefa.d.ts'

const tarefaReqConf = {
  baseURL: adminApiConfig.baseURL + 'tarefa',
}

export const listarTarefa = async () => {
  return await adminApi.get<TarefaListRes>('/', tarefaReqConf)
}

export const criarTarefa = async (tarefa: TarefaCreateReq) => {
  return await adminApi.post<TarefaCreateRes>('/', tarefa, tarefaReqConf)
}

export const obterTarefa = async (id: string) => {
  const { data } = await adminApi.get<TarefaGetRes>('/' + id, tarefaReqConf)
  return data.value[0]
}

export const atualizarTarefa = async (tarefa: Tarefa) => {
  return await adminApi.put<TarefaUpdateRes>('/' + tarefa.Id, tarefa, tarefaReqConf)
}

export const excluirTarefa = async (id: string) => {
  return await adminApi.delete<TarefaDeleteRes>('/' + id, tarefaReqConf)
}    
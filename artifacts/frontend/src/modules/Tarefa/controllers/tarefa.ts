/**
 * arquivo controller trata da parte de erros e interface de usuario
 */
import {
  criarTarefa as _criarTarefa,
  listarTarefa as _listarTarefa,
  obterTarefa as _obterTarefa,
  atualizarTarefa as _atualizarTarefa,
  excluirTarefa as _excluirTarefa,
} from '../api/tarefa'
import type { Tarefa, TarefaCreateReq } from '../types/tarefa'
import { useUiStore } from '@/stores/ui'
import { AxiosError } from 'axios'

export const listarTarefa = async () => {
  try {
    const { data } = await _listarTarefa()
    return data.value
  } catch (error) {
    throw error
  }
}

export const criarTarefa = async (tarefa: TarefaCreateReq) => {
  const ui = useUiStore()

  try {
    const { data } = await _criarTarefa(tarefa)

    ui.exibirAlerta({
      text: data.message,
      color: 'success'
    })

    return true

  } catch (error) {
    if (
      error instanceof AxiosError &&
      error.response?.status === 400 &&
      error.response.data.errors
    ) {
      ui.exibirAlertas(
        error.response.data.errors
          .map((err: { mensagem: string }) => ({ text: err.mensagem, color: 'error' }))
      )

      return false

    } else {
      throw error
    }
  }
}

export const obterTarefa = async (id: string) => {
  try {
    const data = await _obterTarefa(id)
    return data
  } catch (error) {
    throw error
  }
}

export const atualizarTarefa = async (tarefa: Tarefa) => {
  try {
    const { data } = await _atualizarTarefa(tarefa)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirTarefa = async (id: string) => {
  try {
    const { data } = await _excluirTarefa(id)
    return true
  } catch (error) {
    throw error
  }
}

export const excluirTarefas = async (ids: string[]) => {
  try {
    for (const id of ids) {
      const sucesso = await excluirTarefa(id)
    }
    return true
  } catch (error) {
    throw error
  }
}    
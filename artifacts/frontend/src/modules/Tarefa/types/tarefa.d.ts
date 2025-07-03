export type Tarefa = {
  titulo : string
descricao : string
data_vencimento : date
Id : string

}

export type TarefaCreateReq = Pick<Tarefa, "titulo" | "descricao" | "data_vencimento">


export type TarefaListRes = {
  "@odata.context": string
  value: Tarefa[]
}

export type TarefaCreateRes = {
  statusCode: number
  uri: string
  message: string
}

export type TarefaGetRes = TarefaListRes


export type TarefaUpdateRes = {
  statusCode: number
  message: string
}

export type TarefaDeleteRes = TarefaUpdateRes
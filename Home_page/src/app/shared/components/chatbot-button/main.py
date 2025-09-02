from fastapi import FastAPI
from pydantic import BaseModel
from transformers import pipeline
from fastapi.middleware.cors import CORSMiddleware

# Init FastAPI
app = FastAPI()

# Allow Angular frontend to call backend
app.add_middleware(
    CORSMiddleware,
    allow_origins=["http://localhost:4200"],  # Angular dev server
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Load AI model (Hugging Face GPT-2 as example)
chatbot = pipeline("text-generation", model="gpt2")

class Message(BaseModel):
    text: str

@app.post("/chat")
def chat(msg: Message):
    response = chatbot(msg.text, max_length=100, num_return_sequences=1)
    return {"reply": response[0]["generated_text"]}

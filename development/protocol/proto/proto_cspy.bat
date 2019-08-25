@echo off

protoc --csharp_out=../cs/ --python_out=../pb2/ %1

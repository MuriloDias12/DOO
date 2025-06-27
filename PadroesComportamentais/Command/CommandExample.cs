using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class TextEditor
{
    public string Text { get; set; } = "";
}

public class WriteTextCommand : ICommand
{
    private TextEditor _editor;
    private string _text;
    public WriteTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }
    public void Execute() => _editor.Text += _text;
    public void Undo() => _editor.Text = _editor.Text.Substring(0, _editor.Text.Length - _text.Length);
}

public class DeleteTextCommand : ICommand
{
    private TextEditor _editor;
    private string _deleted;
    public DeleteTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _deleted = _editor.Text.Substring(_editor.Text.Length - length, length);
    }
    public void Execute() => _editor.Text = _editor.Text.Substring(0, _editor.Text.Length - _deleted.Length);
    public void Undo() => _editor.Text += _deleted;
}

public class CommandManager
{
    private Stack<ICommand> _undoStack = new();
    private Stack<ICommand> _redoStack = new();
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear();
    }
    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var cmd = _undoStack.Pop();
            cmd.Undo();
            _redoStack.Push(cmd);
        }
    }
    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var cmd = _redoStack.Pop();
            cmd.Execute();
            _undoStack.Push(cmd);
        }
    }
}

public class CommandDemo
{
    public static void Main()
    {
        var editor = new TextEditor();
        var commandManager = new CommandManager();
        commandManager.ExecuteCommand(new WriteTextCommand(editor, "Hello, "));
        commandManager.ExecuteCommand(new WriteTextCommand(editor, "world!"));
        Console.WriteLine(editor.Text);
        commandManager.Undo();
        Console.WriteLine(editor.Text);
        commandManager.Undo();
        Console.WriteLine(editor.Text);
        commandManager.Redo();
        Console.WriteLine(editor.Text);
    }
}

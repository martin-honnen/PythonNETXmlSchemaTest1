using Python.Runtime;

PythonEngine.Initialize();

using var _ = Py.GIL();

dynamic xmlschema = Py.Import("xmlschema");

using dynamic sampleSchema = xmlschema.XMLSchema11("assert-example1.xsd");

Console.WriteLine(sampleSchema.is_valid("names-valid.xml"));

Console.WriteLine(sampleSchema.is_valid("names-invalid.xml"));


try
{
    sampleSchema.validate("names-invalid.xml");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}